using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerRegistrationPortal.DomainLayer
{
   public static class EnumHelper<T>
    {
        public static T Parse(string value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
