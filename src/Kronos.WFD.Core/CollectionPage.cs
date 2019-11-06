using System.Collections.Generic;

namespace Kronos.WFD
{
    public class CollectionPage<T> : ICollectionPage<T>
    {
        public CollectionPage()
        {
            this.CurrentPage = new List<T>();
        }

        public CollectionPage(IList<T> currentPage)
        {
            this.CurrentPage = currentPage;
        }

        public IList<T> CurrentPage { get; private set; }

        public int IndexOf(T item)
        {
            return this.CurrentPage.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.CurrentPage.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.CurrentPage.RemoveAt(index);
        }

        public T this[int index]
        {
            get { return this.CurrentPage[index]; }
            set { this.CurrentPage[index] = value; }
        }

        /// <summary>
        /// Add an item to the current page.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(T item)
        {
            this.CurrentPage.Add(item);
        }

        /// <summary>
        /// Remove all items from the current page.
        /// </summary>
        public void Clear()
        {
            this.CurrentPage.Clear();
        }

        /// <summary>
        /// Determine whether the current page contains the given item.
        /// </summary>
        /// <param name="item">The item to search for.</param>
        /// <returns>True if the item is found.</returns>
        public bool Contains(T item)
        {
            return this.CurrentPage.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the current page to the given array starting at the given index.
        /// </summary>
        /// <param name="array">The array to copy elements to.</param>
        /// <param name="arrayIndex">The start index.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.CurrentPage.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the number of elements in the current page.
        /// </summary>
        public int Count
        {
            get { return this.CurrentPage.Count; }
        }

        /// <summary>
        /// Determines whether the current page is readonly.
        /// </summary>
        public bool IsReadOnly
        {
            get { return this.CurrentPage.IsReadOnly; }
        }

        /// <summary>
        /// Removes an item from the current page.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            return this.CurrentPage.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the current page.
        /// </summary>
        /// <returns>The enumerator for the current page.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.CurrentPage.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.CurrentPage.GetEnumerator();
        }

        public IDictionary<string, object> AdditionalData { get; set; }
    }

    /// <summary>
    /// Interface for collection pages.
    /// </summary>
    /// <typeparam name="T">The type of the collection.</typeparam>
    public interface ICollectionPage<T> : IList<T>
    {
        /// <summary>
        /// The current page of the collection.
        /// </summary>
        IList<T> CurrentPage { get; }

        /// <summary>
        /// The additional data property bag.
        /// </summary>
        IDictionary<string, object> AdditionalData { get; set; }
    }
}
