using System;

namespace Banking.Tests
{
    public class BuilderBase<TItem>
    {
        private readonly TItem _item;

        protected BuilderBase(TItem item) => _item = item;

        protected BuilderBase<TItem> With(Action<TItem> action)
        {
            action(_item);
            return this;
        }

        public TItem Build() => _item;
    }
}