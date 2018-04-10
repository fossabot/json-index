﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DotJEM.Json.Index.Documents.Fields;
using DotJEM.Json.Index.Documents.Info;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.Util;
using Lucene.Net.Util;
using NUnit.Framework;

namespace DotJEM.Json.Index.QueryParsers.Test
{
    [TestFixture]
    public class SimplifiedLuceneQueryParserTest
    {
        [TestCase("value", "")]
        public void Parse_Input_Query(string query, string result)
        {
            SimplifiedLuceneQueryParser parser = new SimplifiedLuceneQueryParser(
                new FakeFieldsInformationManager(),  new StandardAnalyzer(LuceneVersion.LUCENE_48, CharArraySet.EMPTY_SET));

            LuceneQueryInfo queryInfo = parser.Parse(query);
            Assert.That(queryInfo.Query.ToString(), Is.EqualTo(result));
        }
    }

    public class FakeFieldsInformationManager : IFieldInformationManager
    {
        public IFieldResolver Resolver { get; }

        public IEnumerable<string> ContentTypes { get; }
        public IEnumerable<string> AllFields { get; }

        public Task Merge(string contentType, IFieldInformationCollection information)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyFieldinformation Lookup(string fieldName)
        {
            return null;
        }

        public IReadOnlyFieldinformation Lookup(string contentType, string fieldName)
        {
            return null;
        }
    }
}
