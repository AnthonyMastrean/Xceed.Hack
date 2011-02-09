using System.Windows.Threading;

namespace Xceed.Hack.Magic
{
    /// <summary>
    /// Synchronously add a low-priority no-op to the Dispatcher's queue. The call will not return
    /// until all higher priority operations are processed. All queued operations will be pumped.
    ///     [http://kentb.blogspot.com/2008/04/dispatcher-frames.html]
    /// </summary>
    public static class DispatcherHelper
    {
        /// <summary>
        /// Pump all queued operations higher than Background.
        /// </summary>
        public static void DoEvents()
        {
            DoEvents(DispatcherPriority.Background);
        }

        /// <summary>
        /// Pump all queued operations over the specified priority.
        /// </summary>
        /// <param name="priority"></param>
        public static void DoEvents(DispatcherPriority priority)
        {
            System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(priority, new VoidHandler(() => { }));
        }
    }
}