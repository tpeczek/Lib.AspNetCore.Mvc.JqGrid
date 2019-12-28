using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Lib.AspNetCore.Mvc.JqGrid.Core.Services;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Results
{
    /// <summary>
    /// Represents a class that is used to send object from Lib.AspNetCore.Mvc.JqGrid.Core namespace as JSON-formatted content to the response, converted the way jqGrid expects it.
    /// </summary>
    public sealed class JqGridJsonResult :  JsonResult
    {
        #region Constructor
        /// <summary>
        /// Initializes new instance of <see cref="JqGridJsonResult"/> class.
        /// </summary>
        /// <param name="value">The value to be send.</param>
        public JqGridJsonResult(object value)
            :base(value)
        { }

        /// <summary>
        /// Initializes new instance of <see cref="JqGridJsonResult"/> class.
        /// </summary>
        /// <param name="value">The value to be send.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        public JqGridJsonResult(object value, object serializerSettings)
            :base(value, serializerSettings)
        {}
        #endregion

        #region Methods
        /// <inheritdoc />
        public override Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            IJqGridJsonService jqGridJsonService = context.HttpContext.RequestServices.GetRequiredService<IJqGridJsonService>();
            IActionResultExecutor<JsonResult> jsonResultExecutor = context.HttpContext.RequestServices.GetRequiredService<IActionResultExecutor<JsonResult>>();

            return jsonResultExecutor.ExecuteAsync(context, new JsonResult(Value, jqGridJsonService.GetJqGridJsonResultSerializerSettings(SerializerSettings))
            {
                ContentType = ContentType,
                StatusCode = StatusCode
            });
        }
        #endregion
    }
}
