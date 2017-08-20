using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Internal;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Helpers
{
    internal static class CompatibilityHelper
    {
        internal static Task CompletedTask
        {
            get
            {
#if ASPNETCORE10 && !NETSTANDARD2_0
                return TaskCache.CompletedTask;
#elif NETSTANDARD2_0
                return Task.CompletedTask;
#else
            // Not implemented, compiler break
#endif
            }
        }
    }
}
