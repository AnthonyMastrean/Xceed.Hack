Do you use the Xceed WPF DataGrid and want to run tests against the virtualizing collections? You've probably noticed that when running a test against your view model from MSTest, that the virtual items are not realizing. The realization is tied to some voodoo inside the WPF implementation. I've found that by pumping the WPF dispatcher you can make the virtual item realize.

In this example, your view model exposes a CollectionView property that's backed by a DataGridVirtualizingCollectionView. There are other ways to express the same idea, but this library works on the CollectionView type.

    public class ViewModel
    {
        public CollectionView Parts
        {
            get { return _partsSource; }
        }
    }

Instead of the usual GetItemAt(int), you'll call the extension method GetRealItemAt(int, timespan). Inside there is a loop, pumping the WPF dispatcher, and checking to see if the item at the index has been realized.

    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void Test()
        {
            var part = vm.Parts.GetRealItemAt<Part>(3, TimeSpan.FromSeconds(1));
        }
    }