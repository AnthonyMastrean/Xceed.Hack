using System;
using System.Collections.Generic;
using System.Windows.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xceed.Hack.Test
{
    [TestClass]
    public class TypedCollection
    {
        private readonly List<string> _list = new List<string> { "item1" };
        private readonly CollectionView _collection;

        public TypedCollection()
        {
            _collection = new CollectionView(_list);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void GetTheWrongTypeThrowsInvalidCast()
        {
            _collection.GetRealItemAt<int>(0, TimeSpan.FromSeconds(1));
        }

        [TestMethod]
        public void GetRealItemCasts()
        {
            Assert.IsNotNull(_collection.GetRealItemAt<string>(0, TimeSpan.FromSeconds(1)));
        }
    }
}