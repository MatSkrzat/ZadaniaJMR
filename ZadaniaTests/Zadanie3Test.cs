using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZadaniaTests
{
    [TestClass]
    public class Zadanie3Test
    {
        [TestMethod]
        public void TestOnlyBigCollections_getsCollectionBiggerThan5()
        {
            var collectionBiggerThan5 = Zadanie3.Iterate.OnlyBigCollections(new List<IEnumerable<string>>
                {
                    new List<string>()
                    {
                        "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa"
                    },
                    new List<string>()
                    {
                        "kwa", "kwa", "kwa"
                    },new List<string>()
                    {
                        "kwa", "kwa"
                    },new List<string>()
                    {
                        "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa"
                    },new List<string>()
                    {
                        "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa"
                    },new List<string>()
                    {
                        "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa"
                    },new List<string>()
                    {
                        "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa", "kwa"
                    },
                }
            );
            Assert.AreEqual(collectionBiggerThan5.Count(), 5);
        }

        [TestMethod]
        public void TestOnlyBigCollections_emptyCollection()
        {
            var collection = Zadanie3.Iterate.OnlyBigCollections(new List<IEnumerable<string>>());
            Assert.AreEqual(collection.Count(), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestOnlyBigCollections_nullCollection()
        {
            var collection = Zadanie3.Iterate.OnlyBigCollections(null);
        }
    }
}