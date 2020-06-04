using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RutasCheck.Helpers
{
    interface IHash
    {
        public static string GetSha256(string str) {
            return str;
        }
    }
}
