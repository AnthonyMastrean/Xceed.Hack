using System;
using System.Windows.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xceed.Hack.Test
{
    [TestClass]
    public class NullCollection
    {
        private readonly CollectionView _collection;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test()
        {
            _collection.GetRealItemAt(0, TimeSpan.FromSeconds(1));
        }
    }
}