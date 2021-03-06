using NUnit.Framework;
using System;

namespace OpenMcdf.Test
{
    /// <summary>
    ///This is a test class for SectorCollectionTest and is intended
    ///to contain all SectorCollectionTest Unit Tests
    ///</summary>
    [TestFixture]
    public class SectorCollectionTest
    {
        /// <summary>
        ///A test for Count
        ///</summary>
        [Test]
        public void CountTest()
        {
            int count = 0;

            SectorCollection target = new SectorCollection(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Count;

            Assert.IsTrue(actual == count);
            Sector s = new Sector(4096);

            target.Add(s);
            Assert.IsTrue(target.Count == actual + 1);


            for (int i = 0; i < 5000; i++)
                target.Add(s);

            Assert.IsTrue(target.Count == actual + 1 + 5000);
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [Test]
        public void ItemTest()
        {
            int count = 37;

            SectorCollection target = new SectorCollection();
            int index = 0;

            Sector expected = new Sector(4096);
            target.Add(null);

            Sector actual;
            target[index] = expected;
            actual = target[index];

            Assert.AreEqual(expected, actual);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Id == expected.Id);

            actual = null;

            try
            {
                actual = target[count + 100];
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }

            try
            {
                actual = target[-1];
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }
        }

        /// <summary>
        ///A test for SectorCollection Constructor
        ///</summary>
        [Test]
        public void SectorCollectionConstructorTest()
        {
            SectorCollection target = new SectorCollection();

            Assert.IsNotNull(target);
            Assert.IsTrue(target.Count == 0);

            Sector s = new Sector(4096);
            target.Add(s);
            Assert.IsTrue(target.Count == 1);
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [Test]
        public void AddTest()
        {
            SectorCollection target = new SectorCollection();
            for (int i = 0; i < 579; i++)
            {
                target.Add(null);
            }


            Sector item = new Sector(4096);
            target.Add(item);
            Assert.IsTrue(target.Count == 580);
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        [Test]
        public void GetEnumeratorTest()
        {
            SectorCollection target = new SectorCollection();
            for (int i = 0; i < 579; i++)
            {
                target.Add(null);
            }


            Sector item = new Sector(4096);
            target.Add(item);
            Assert.IsTrue(target.Count == 580);

            int cnt = 0;
            foreach (Sector s in target)
            {
                cnt++;
            }

            Assert.IsTrue(cnt == target.Count);
        }
    }
}