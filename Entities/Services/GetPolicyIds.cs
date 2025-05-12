using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Services
{
    public static class GetPolicyIds
    {
        public static string GetPolicyId()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("POLIZ").Append(Guid.NewGuid().ToString("N").Substring(0, 12).ToUpper());
            return sb.ToString();
        }
    }
}
