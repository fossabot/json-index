﻿using System;
using System.Collections.Generic;
using System.Text;
using DotJEM.Json.Index.IO;
using DotJEM.Json.Index.Searching;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Support;
using Lucene.Net.Util;

namespace DotJEM.Json.Index.Storage
{
    public static class StorageProviders
    {
        public static ILuceneStorageProvider RamStorage() => new LuceneRamStorageProvider();
        public static ILuceneStorageProvider SimpleFileStorage(string path) => new LuceneSimpleFileSystemStorageProvider(path);
    }
    public interface ILuceneStorageProvider
    {
        IJsonIndexStorage Create(ILuceneJsonIndex index, LuceneVersion version);
    }

    public interface IJsonIndexStorage
    {
        bool Exists { get; }

        IIndexWriterManager WriterManager { get; }
        IIndexSearcherManager SearcherManager { get; }

        void Unlock();
        void Delete();
    }

    public class LuceneRamStorageProvider : ILuceneStorageProvider
    {
        public IJsonIndexStorage Create(ILuceneJsonIndex index, LuceneVersion configurationVersion) => new JsonIndexStorage(index, new RAMDirectory());
    }

    public class LuceneSimpleFileSystemStorageProvider : ILuceneStorageProvider
    {
        private readonly string path;
        public LuceneSimpleFileSystemStorageProvider(string path) => this.path = path;
        public IJsonIndexStorage Create(ILuceneJsonIndex index, LuceneVersion configurationVersion) => new JsonIndexStorage(index, new SimpleFSDirectory(path));
    }

    public class JsonIndexStorage : IJsonIndexStorage
    {
        private readonly LuceneVersion version = LuceneVersion.LUCENE_48;
        private readonly Directory directory;

        public bool Exists => DirectoryReader.IndexExists(directory);

        public IIndexWriterManager WriterManager { get; private set; }
        public IIndexSearcherManager SearcherManager { get; private set; }

        public JsonIndexStorage(ILuceneJsonIndex index, Directory directory)
        {
            this.directory = directory;

            IndexWriterConfig config = new IndexWriterConfig(version, index.Services.Resolve<Analyzer>());
            config.SetRAMBufferSizeMB(512);
            config.SetOpenMode(OpenMode.CREATE_OR_APPEND);
            config.IndexDeletionPolicy = new SnapshotDeletionPolicy(config.IndexDeletionPolicy);

            WriterManager = new IndexWriterManager(new IndexWriter(directory, config));
            SearcherManager = new IndexSearcherManager(WriterManager);
        }

        public void Unlock()
        {
            if (IndexWriter.IsLocked(directory))
                IndexWriter.Unlock(directory);
        }

        public virtual void Delete()
        {
            IndexWriterConfig config = new IndexWriterConfig(version, new StandardAnalyzer(version));
            config.SetRAMBufferSizeMB(512);
            config.SetOpenMode(OpenMode.CREATE);

            WriterManager.Dispose();
            WriterManager = new IndexWriterManager(new IndexWriter(directory, config));
            SearcherManager = new IndexSearcherManager(WriterManager);
            Unlock();


        }
    }
}
