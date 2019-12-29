using System;
using System.Text.Json;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Json
{
    internal class JqGridJsonWriter : IJqGridJsonWriter
    {
        #region Fields
        private readonly Utf8JsonWriter _innerWriter;
        private readonly JsonSerializerOptions _innerWriterOptions;
        #endregion

        #region Constructor
        public JqGridJsonWriter(Utf8JsonWriter innerWriter, JsonSerializerOptions innerWriterOptions)
        {
            _innerWriter = innerWriter ?? throw new ArgumentNullException(nameof(innerWriter));
            _innerWriterOptions = innerWriterOptions;
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
            _innerWriter.WriteString(name, value);
        }

        public void WriteProperty(string name, int value)
        {
            _innerWriter.WriteNumber(name, value);
        }

        public void WriteProperty(string name, object value)
        {
            _innerWriter.WritePropertyName(name);
            JsonSerializer.Serialize(_innerWriter, value, _innerWriterOptions);
        }

        public void WriteStartArray(string name)
        {
            _innerWriter.WriteStartArray(name);
        }

        public void WriteEndArray()
        {
            _innerWriter.WriteEndArray();
        }
        #endregion
    }
}
