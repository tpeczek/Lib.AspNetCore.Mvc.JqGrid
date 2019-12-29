using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Lib.AspNetCore.Mvc.JqGrid.Core.Json;

namespace Lib.AspNetCore.Mvc.JqGrid.NewtonsoftJson
{
    internal struct NewtonsoftJqGridJsonElement : IJqGridJsonElement
    {
        #region Fields
        private readonly JToken _innerElement;
        #endregion

        #region Properties
        public IJqGridJsonElement this[string key]
        {
            get
            {
                JToken elementAtKey = _innerElement[key];

                return (elementAtKey is null) ? null : (IJqGridJsonElement)new NewtonsoftJqGridJsonElement(elementAtKey);
            }
        }

        public JqGridJsonElementType Type
        {
            get
            {
                return _innerElement.Type switch
                {
                    JTokenType.String => JqGridJsonElementType.String,
                    JTokenType.Array => JqGridJsonElementType.Array,
                    _ => JqGridJsonElementType.Unknown,
                };
            }
        }
        #endregion

        #region Constructor
        public NewtonsoftJqGridJsonElement(JToken innerElement)
        {
            _innerElement = innerElement ?? throw new ArgumentNullException(nameof(innerElement));
        }
        #endregion

        #region Methods
        public string GetString()
        {
            return _innerElement.Value<String>();
        }

        public IEnumerable<IJqGridJsonElement> EnumerateArray()
        {
            return _innerElement.Select(arrayInnerElement => (IJqGridJsonElement)new NewtonsoftJqGridJsonElement(arrayInnerElement));
        }
        #endregion
    }
}
