using System;
using System.Collections.Generic;
using System.Windows.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xceed.Hack.Test
{
    [TestClass]
    public class NeverRealizedCollection
    {
        private readonly List<object> _list = new List<object> { XceedReflection.Empty };
        private readonly CollectionView _collection;

        public NeverRealizedCollection()
        {
            _collection = new CollectionView(_list);
        }

        [TestMethod]
        [ExpectedException(typeof(VirtualItemNotRealizedException))]
        public void Test()
        {
            _collection.GetRealItemAt(0, TimeSpan.FromSeconds(1));
        }
    }
}