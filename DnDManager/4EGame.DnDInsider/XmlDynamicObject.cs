﻿namespace Game.DnDInsider
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Dynamic;

    public class XmlDynamicObject : DynamicObject, IDictionary<string, object>
    {
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(KeyValuePair<string, object> item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            throw new System.NotImplementedException();
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; private set; }

        public bool ContainsKey(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Add(string key, object value)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetValue(string key, out object value)
        {
            throw new System.NotImplementedException();
        }

        public object this[string key]
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public ICollection<string> Keys { get; private set; }

        public ICollection<object> Values { get; private set; }
    }
}