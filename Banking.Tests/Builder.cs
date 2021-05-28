using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xunit.Sdk;

namespace Banking.Tests
{
    public abstract class Builder<TBuilder, TItem> where TBuilder : Builder<TBuilder, TItem>
    {
        private Func<TItem> _item;
        private readonly List<Action<TItem>> _actions = new List<Action<TItem>>();

        public Builder<TBuilder, TItem> As(Func<TItem> item)
        {
            _item = item;
            return this;
        }

        public TBuilder With(Action<TItem> action)
        {
            _actions.Add(action);
            return (TBuilder) this;
        }

        public static implicit operator TItem(Builder<TBuilder, TItem> builder) => builder.Build();

        public TItem Build()
        {
            var item = _item();
            foreach (var action in _actions)
            {
                action(item);
            }
            _actions.Clear();
            return item;
        }
    }
}