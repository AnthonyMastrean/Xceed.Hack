using System;
using System.Windows.Data;

namespace Xceed.Hack
{
    public static class CollectionViewExtensions
    {
        /// <summary>
        /// Get the real item at the specified index.
        /// </summary>
        public static T GetRealItemAt<T>(this CollectionView collection, int index, TimeSpan timeout)
        {
            return (T)GetRealItemAt(collection, index, timeout);
        }

        /// <summary>
        /// Get the real item at the specified index.
        /// </summary>
        public static object GetRealItemAt(this CollectionView collection, int index, TimeSpan timeout)
        {
            return new RealizingWrapper(collection, timeout).GetRealItemAt(index);
        }
    }
}