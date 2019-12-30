using System;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Json
{
    /// <summary>
    /// Provides an abstraction for a writer that provides a fast, non-cached, forward-only way of generating JSON.
    /// </summary>
    public interface IJqGridJsonWriter
    {
        /// <summary>
        /// Writes the beginning of a JSON object.
        /// </summary>
        void WriteStartObject();

        /// <summary>
        /// Writes the end of a JSON object.
        /// </summary>
        void WriteEndObject();

        /// <summary>
        /// Writes a name/value pair of a JSON object.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The <see cref="String"/> value to write.</param>
        void WriteProperty(string name, string value);

        /// <summary>
        /// Writes a name/value pair of a JSON object.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The <see cref="Int32"/> value to write.</param>
        void WriteProperty(string name, int value);

        /// <summary>
        /// Writes a name/value pair of a JSON object.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The <see cref="Object"/> value to write.</param>
        void WriteProperty(string name, object value);

        /// <summary>
        /// Writes the beginning of a JSON array.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        void WriteStartArray(string name);
   
        /// <summary>
        /// Writes the end of an array.
        /// </summary>
        void WriteEndArray();
    }
}
