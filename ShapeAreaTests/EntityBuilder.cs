using System;
using System.Collections.Generic;

namespace ShapeAreaTests
{
    public abstract class EntityBuilder<TEntity, TBuilder> where TBuilder : EntityBuilder<TEntity, TBuilder>
    {
        private Dictionary<string, object> Values { get; } = new();

        protected TBuilder SetValue<TValue>(string key, TValue value)
        {
            Values[key] = value;
            return (TBuilder)this;
        }

        protected TValue GetValue<TValue>(string key, TValue defaultValue = default)
        {
            return Values.TryGetValue(key, out var savedValue)
                ? (TValue)savedValue
                : defaultValue;
        }

        public abstract TEntity Build();
    }
}