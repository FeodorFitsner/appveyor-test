using System;
using System.Linq;
using System.Text;

namespace Core
{
    public static class Random
    {
        public static int Generate()
        {
            var shortGuidHandler = new ShortGuid.ShortGuidHandler();
            var t = shortGuidHandler.Parse(Guid.NewGuid());
            var i = t.ToString() + ShortGuid.Concat("z");
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

        public static string Concat(string toto)
        {
            return toto.Trim() + "qa";
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
