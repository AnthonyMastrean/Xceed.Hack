using System;

namespace Xceed.Hack
{
    [Serializable]
    public class VirtualItemNotRealizedException : Exception
    {
        private const string DefaultMessage = "The virtual item was not realized.";

        public VirtualItemNotRealizedException()
            : base(DefaultMessage)
        {
        }
    }
}