using System.Collections.ObjectModel;

namespace WpfMockupApp8.Utilities
{
    public static class ListUtils
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
    }
}
