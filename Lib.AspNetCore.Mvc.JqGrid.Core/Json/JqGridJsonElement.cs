using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Json
{
    internal struct JqGridJsonElement : IJqGridJsonElement
    {
        #region Fields
        private readonly JsonElement _innerElement;
        #endregion

        #region Properties
        public IJqGridJsonElement this[string key]
        {
            get
            {
                if (_innerElement.TryGetProperty(key, out JsonElement elementAtKey))
                {
                    return new JqGridJsonElement(elementAtKey);
                }

                return null;
            }
        }

        public JqGridJsonElementType Type
        {
            get
            {
                return _innerElement.ValueKind switch
                {
                    JsonValueKind.String => JqGridJsonElementType.String,
                    JsonValueKind.Array => JqGridJsonElementType.Array,
                    _ => JqGridJsonElementType.Unknown,
                };
            }
        }
        #endregion

        #region Constructor
        public JqGridJsonElement(JsonElement innerElement)
        {
            _innerElement = innerElement;
        }
        #endregion

        #region Methods
        public string GetString()
        {
            return _innerElement.GetString();
        }

        public IEnumerable<IJqGridJsonElement> EnumerateArray()
        {
            return _innerElement.EnumerateArray().Select(arrayInnerElement => (IJqGridJsonElement)new JqGridJsonElement(arrayInnerElement));
        }
        #endregion
    }
}
