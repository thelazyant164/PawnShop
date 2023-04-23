using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Script.Utility
{
    public static class EnumExtension
    {
        public static T GetRandomValue<T>(this Type type) where T : Enum => Enum.GetValues(type).OfType<T>().OrderBy(e => Guid.NewGuid()).First();
    }
}
