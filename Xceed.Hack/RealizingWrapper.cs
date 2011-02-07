using System;
using System.Diagnostics;
using System.Windows.Data;
using Xceed.Hack.Diagnostics;
using Xceed.Hack.Dispatcher;

namespace Xceed.Hack
{
    public class RealizingWrapper
    {
        private readonly CollectionView _collection;
        private readonly TimeSpan _timeout;

        public RealizingWrapper(CollectionView collection, TimeSpan timeout)
        {
            _collection = collection;
            _timeout = timeout;
        }

        public object GetRealItemAt(int index)
        {
            var loops = 0;
            var timeout = new LazyTimeout(_timeout);
            
            var item = XceedReflection.Empty;
            while (item.GetType() == XceedReflection.EmptyType)
            {
                if (timeout.HasExpired)
                {
                    throw new VirtualItemNotRealizedException();
                }

                DispatcherHelper.DoEvents();
                item = _collection.GetItemAt(index);

                loops++;
            }

            Debug.Print("Called GetItemAt {0}x ({1} ms).", loops, timeout.GetElapsedTime().TotalMilliseconds);
            return item;
        }
    }
}