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
                return Task.CompletedTask;
            }
        }
    }
}
