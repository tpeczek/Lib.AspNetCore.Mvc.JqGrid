using System;
using Newtonsoft.Json;
using Lib.AspNetCore.Mvc.JqGrid.Core.Json;

namespace Lib.AspNetCore.Mvc.JqGrid.NewtonsoftJson
{
    internal class NewtonsoftJqGridJsonWriter : IJqGridJsonWriter
    {
        #region Fields
        private readonly JsonWriter _innerWriter;
        private readonly JsonSerializer _innerWriterSerializer;
        #endregion

        #region Constructor
        public NewtonsoftJqGridJsonWriter(JsonWriter innerWriter, JsonSerializer innerWriterSerializer)
        {
            _innerWriter = innerWriter ?? throw new ArgumentNullException(nameof(innerWriter));
            _innerWriterSerializer = innerWriterSerializer;
        }
        #endregion

        #region Methods
        public void WriteStartObject()
        {
            _innerWriter.WriteStartObject();
        }

        public void WriteEndObject()
        {
            _innerWriter.WriteEndObject();
        }

        public void WriteProperty(string name, string value)
        {
            _innerWriter.WritePropertyName(name);
            _innerWriter.WriteValue(value);
        }

        public void WriteProperty(string name, int value)
        {
            _innerWriter.WritePropertyName(name);
            _innerWriter.WriteValue(value);
        }

        public void WriteProperty(string name, object value)
        {
            _innerWriter.WritePropertyName(name);
            _innerWriterSerializer.Serialize(_innerWriter, value);
        }

        public void WriteStartArray(string name)
        {
            _innerWriter.WritePropertyName(name);
            _innerWriter.WriteStartArray();
        }

        public void WriteEndArray()
        {
            _innerWriter.WriteEndArray();
        }
        #endregion
    }
}
