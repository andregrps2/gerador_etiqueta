using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Classes.Bases
{
    public interface IBaseCollection
    {
        BaseModel GetIndex(int i);
        int GetHashCodeInitializedItem();
    }

    public class BaseCollection<T> : BindingList<T>, IBaseCollection, ITypedList
    {
        private const int MAX_RECURSION = 10;

        public bool IsMasterDetail { get; set; }

        public delegate void AddItemHandler(int index, T item);
        public delegate void RemoveItemHandler(int index);

        public event AddItemHandler OnAddItem;
        public event RemoveItemHandler OnRemoveItem;

        readonly IList<T> deletedItems;
        T initializedItem;

        public BaseCollection() : base(new List<T>())
        {
            deletedItems = new List<T>();
            comparers = new Dictionary<Type, PropertyComparer<T>>();
        }
        public BaseCollection(IEnumerable<T> enumeration) : base(new List<T>(enumeration))
        {
            deletedItems = new List<T>();
            comparers = new Dictionary<Type, PropertyComparer<T>>();
        }

        public IList<T> DeletedItems
        {
            get
            {
                IList<T> lst = new List<T>();
                foreach (T del in deletedItems)
                    if (del is BaseModel)
                        if ((del as BaseModel).DataObjectState == DataObjectStateEnum.Confirmed || (del as BaseModel).DataObjectState == DataObjectStateEnum.Modified)
                            lst.Add(del);
                return lst;
            }
        }

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            if (OnAddItem != null)
                OnAddItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            OnRemoveItem?.Invoke(index);
            deletedItems.Add(Items[index]);
            base.RemoveItem(index);
        }

        BaseModel IBaseCollection.GetIndex(int index)
        {
            return this[index] as BaseModel;
        }
        int IBaseCollection.GetHashCodeInitializedItem()
        {
            if (initializedItem == null)
                return 0;
            return initializedItem.GetHashCode();
        }
        public void RestoreValues()
        {
            try
            {
                foreach (T item in this)
                    deletedItems.Add(item);
                Clear();
                foreach (T deletedItem in DeletedItems)
                    if (deletedItem is BaseModel)
                        Add(deletedItem);
                deletedItems.Clear();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ClearDeletedItems()
        {
            deletedItems.Clear();
        }
        public void InitializeCollection(T item)
        {
            initializedItem = item;
            Items.Add(item);
        }
        public void AddList(IList<T> listModel)
        {
            if (listModel != null)
            {
                foreach (T item in listModel)
                    Add(item);
            }
        }
        public void AddEnumerable(IEnumerable<T> listModel)
        {
            if (listModel != null)
            {
                foreach (T item in listModel)
                    Add(item);
            }
        }

        #region AggregatedPropertyDescriptor

        IEnumerable<PropertyDescriptor> GetPropertiesRecursive(Type t, PropertyDescriptor parent, Attribute[] attributes, int depth)
        {
            if (depth >= MAX_RECURSION)
                yield break;

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(t, attributes))
            {
                if (property.PropertyType != typeof(Type))
                {
                    yield return (parent == null) ? property : new AggregatedPropertyDescriptor(parent, property, attributes);
                    foreach (PropertyDescriptor aggregated in GetPropertiesRecursive(property.PropertyType, parent, attributes, depth + 1))
                        yield return new AggregatedPropertyDescriptor(property, aggregated, attributes);
                }
            }
        }
        string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
        {
            return GetType().Name;
        }
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            PropertyDescriptorCollection pdc = new PropertyDescriptorCollection(null);
            Attribute[] attributes = new Attribute[] { new BrowsableAttribute(true) };

            foreach (PropertyDescriptor property in GetPropertiesRecursive(typeof(T), null, attributes, 1))
                pdc.Add(property);
            return pdc;
        }

        #endregion

        #region SortableBindingList

        private readonly Dictionary<Type, PropertyComparer<T>> comparers;
        private bool isSorted;
        private ListSortDirection listSortDirection;
        private PropertyDescriptor propertyDescriptor;

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
        protected override bool IsSortedCore
        {
            get { return isSorted; }
        }
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return propertyDescriptor; }
        }
        protected override ListSortDirection SortDirectionCore
        {
            get { return listSortDirection; }
        }
        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }
        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> itemsList = (List<T>)Items;

            Type propertyType = property.PropertyType;
            if (!comparers.TryGetValue(propertyType, out PropertyComparer<T> comparer))
            {
                comparer = new PropertyComparer<T>(property, direction);
                comparers.Add(propertyType, comparer);
            }

            comparer.SetPropertyAndDirection(property, direction);
            itemsList.Sort(comparer);

            propertyDescriptor = property;
            listSortDirection = direction;
            isSorted = true;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        protected override void RemoveSortCore()
        {
            isSorted = false;
            propertyDescriptor = base.SortPropertyCore;
            listSortDirection = base.SortDirectionCore;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        protected override int FindCore(PropertyDescriptor property, object key)
        {
            int count = Count;
            for (int i = 0; i < count; ++i)
            {
                T element = this[i];
                if (property.GetValue(element).Equals(key))
                    return i;
            }
            return -1;
        }

        #endregion
    }

    public class AggregatedPropertyDescriptor : PropertyDescriptor
    {
        public override Type ComponentType
        {
            get
            {
                return AggregatedProperty.ComponentType;
            }
        }
        public PropertyDescriptor AggregatedProperty { get; private set; }
        public override bool IsReadOnly
        {
            get
            {
                return AggregatedProperty.IsReadOnly;
            }
        }
        public PropertyDescriptor OwningProperty { get; private set; }
        public override Type PropertyType
        {
            get
            {
                return AggregatedProperty.PropertyType;
            }
        }
        public AggregatedPropertyDescriptor(PropertyDescriptor owner, PropertyDescriptor aggregated, Attribute[] attributes)
            : base(owner.Name + "->" + aggregated.Name, attributes)
        {
            OwningProperty = owner;
            AggregatedProperty = aggregated;
        }
        public override bool CanResetValue(object component)
        {
            return AggregatedProperty.CanResetValue(component);
        }
        public override object GetValue(object component)
        {
            return AggregatedProperty.GetValue(OwningProperty.GetValue(component));
        }
        public override void ResetValue(object component)
        {
            AggregatedProperty.ResetValue(component);
        }
        public override void SetValue(object component, object value)
        {
            AggregatedProperty.SetValue(OwningProperty.GetValue(component), value);
        }
        public override bool ShouldSerializeValue(object component)
        {
            return AggregatedProperty.ShouldSerializeValue(component);
        }
    }
}
