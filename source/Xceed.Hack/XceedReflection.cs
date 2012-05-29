using System;
using System.Reflection;

namespace Xceed.Hack
{
    /// <summary>
    /// Expose Xceed's internal virtual "empty data item" types and instances.
    /// </summary>
    public class XceedReflection
    {
        private const string AssemblyName = "Xceed.Wpf.DataGrid";
        private const string ItemName = "Xceed.Wpf.DataGrid.EmptyDataItem";

        public static readonly Type EmptyType = Assembly.Load(AssemblyName).GetType(ItemName);
        public static readonly object Empty = Activator.CreateInstance(EmptyType, true);
    }
}