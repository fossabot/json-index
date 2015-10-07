﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Documents;
using Lucene.Net.Index;

namespace DotJEM.Json.Index.Sharding.Commands
{
    public interface IDocumentCommand
    {
        void Execute(IndexWriter writer);
    }

    public class UpdateDocument : IDocumentCommand
    {
        private readonly Term term;
        private readonly Document document;

        public UpdateDocument(Term term, Document document)
        {
            this.term = term;
            this.document = document;
        }

        public void Execute(IndexWriter writer)
        {
            writer.UpdateDocument(term, document);
        }
    }

    public class DeleteDocument : IDocumentCommand
    {
        private readonly Term term;

        public DeleteDocument(Term term)
        {
            this.term = term;
        }

        public void Execute(IndexWriter writer)
        {
            //TODO: (jmd 2015-10-07) Delete can be improved by passing a list of terms.
            //                       we would need another pattern in that case.
            //                       so lets focus on more important stuff rignt now. 
            writer.DeleteDocuments(term);
        }
    }

    public interface IShardCommand
    {
        void Execute();
    }

    public class UpdateShardCommand : IShardCommand
    {
        private readonly IJsonIndexShard shard;
        private readonly IEnumerable<UpdateDocument> updates;

        public UpdateShardCommand(IJsonIndexShard shard, IEnumerable<UpdateDocument> updates)
        {
            this.shard = shard;
            this.updates = updates;
        }

        public void Execute()
        {
            IndexWriter writer = shard.OpenWriter();
            foreach (UpdateDocument update in updates)
            {
                update.Execute(writer);
            }
        }
    }
}
