using System;
using System.Collections.Generic;
using System.Windows.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xceed.Hack.Test
{
    [TestClass]
    public class EmptyCollection
    {
        private readonly CollectionView _collection = new CollectionView(new List<object>());

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test()
        {
            _collection.GetRealItemAt(0, TimeSpan.FromSeconds(1));
        }
    }
}