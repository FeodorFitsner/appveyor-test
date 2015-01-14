using System;

namespace Core
{
    public static class Random
    {
        public static int Generate()
        {
            var shortGuidHandler = new ShortGuid.ShortGuidHandler();
            var t = shortGuidHandler.Parse(Guid.NewGuid());
            var i = t.ToString();
            return i.GetHashCode();
        }
    }
}


namespace Core
{
    public class ShortGuid
    {
        private string _value;

        private ShortGuid(Guid value)
        {
            _value = value.ToString();
        }

        public override string ToString()
        {
            return _value;
        }

        internal class ShortGuidHandler
        {
            public ShortGuid Parse(object value)
            {
                return new ShortGuid((Guid)value);
            }
        }

    }
}
