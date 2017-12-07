using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SearchTap.Tests
{
    [TestFixture]
    public class SearchTapClientTests
    {
        private readonly string _key = "";
        private readonly string _collection = "";

        [Test]
        public void CanIndexDocuments()
        {
            var client = new SearchTapClient(_collection, _key);

            var sampleData = new List<dynamic>();

            foreach (var i in Enumerable.Range(1, 1000))
            {
                sampleData.Add(new
                {
                    Id = i,
                    Name = $"Sample Name {i}",
                    Age = i + 20
                });
            }

            Assert.That(() => client.Index(sampleData), Throws.Nothing);
        }
    }
}