using System;
using System.Collections.Generic;
using System.Text;

namespace Fcz.Navi.Api.Models.Extensions
{
    public static class ModelExtension
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
