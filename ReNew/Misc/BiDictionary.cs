using System;
using System.Collections.Generic;

namespace ReNew.Misc
{
    public class BiDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _forward = new Dictionary<TKey, TValue>();
        private readonly Dictionary<TValue, TKey> _reverse = new Dictionary<TValue, TKey>();

        public void Add(TKey key, TValue value)
        {
            if (_forward.ContainsKey(key) || _reverse.ContainsKey(value))
                throw new ArgumentException("Duplicate key or value");

            _forward[key] = value;
            _reverse[value] = key;
        }

        public bool TryGetByKey(TKey key, out TValue value) => _forward.TryGetValue(key, out value);
        public bool TryGetByValue(TValue value, out TKey key) => _reverse.TryGetValue(value, out key);

        public bool RemoveByKey(TKey key)
        {
            if (_forward.TryGetValue(key, out var value))
            {
                _forward.Remove(key);
                _reverse.Remove(value);
                return true;
            }
            return false;
        }

        public bool RemoveByValue(TValue value)
        {
            if (_reverse.TryGetValue(value, out var key))
            {
                _reverse.Remove(value);
                _forward.Remove(key);
                return true;
            }
            return false;
        }

        public IEnumerable<TKey> Keys => _forward.Keys;
        public IEnumerable<TValue> Values => _forward.Values;

        public int Count => _forward.Count;
    }
}
