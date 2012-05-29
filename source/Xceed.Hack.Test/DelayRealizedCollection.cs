using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xceed.Hack.Test
{
    [TestClass]
    public class DelayRealizedCollection
    {
        private readonly List<object> _list = new List<object> { XceedReflection.Empty };

        private readonly CollectionView _collection;
        private readonly Thread _initializer;

        public DelayRealizedCollection()
        {
            _collection = new CollectionView(_list);
            _initializer = new Thread(x =>
                                          {
                                              Thread.Sleep(100);
                                              _list[0] = new object();
                                          });
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _initializer.Start();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _initializer.Join();
        }

        [TestMethod]
        public void Test()
        {
            Assert.IsNotNull(_collection.GetRealItemAt(0, TimeSpan.FromSeconds(1)));
        }
    }
}