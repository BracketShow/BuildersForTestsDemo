using System;
using System.Collections.Generic;

namespace Banking.Tests
{
    public class BuilderBase<TItem> where TItem : new()
    {
        protected readonly Func<TItem> _item;
        private List<Action<TItem>> _actions = new List<Action<TItem>>();

        protected BuilderBase(Func<TItem> item)
        {
            _item = item;
        }

        public BuilderBase<TItem> With(Action<TItem> action)
        {
            _actions.Add(action);
            return this;
        }

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