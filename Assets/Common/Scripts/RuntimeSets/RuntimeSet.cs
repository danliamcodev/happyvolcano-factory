using System.Collections.Generic;
using UnityEngine;

namespace SickLab.RuntimeSets
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        [SerializeField] protected List<T> _items = new List<T>();

        public int count { get { return _items.Count; } }
        public List<T> items { get { return _items; } }

        public T this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        public virtual void Add(T item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }

        public virtual void Remove(T item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
            }
        }
    }
}