using System;
using System.Collections.Generic;

namespace Lib.AspNetCore.Mvc.JqGrid.Core.Json
{
    /// <summary>
    /// Provides an abstraction for a specific JSON value within an object.
    /// </summary>
    public interface IJqGridJsonElement
    {
        /// <summary>
        /// Gets the <see cref="IJqGridJsonElement"/> with the specified key.
        /// </summary>
        /// <param name="key">The specified key.</param>
        /// <returns>The <see cref="IJqGridJsonElement"/></returns>
        IJqGridJsonElement this[string key] { get; }

        /// <summary>
        /// Gets the node type for this <see cref="IJqGridJsonElement"/>.
        /// </summary>
        JqGridJsonElementType Type { get; }

        /// <summary>
        /// Gets the value of the element as a <see cref="String"/>.
        /// </summary>
        /// <returns>The value of the element as a <see cref="String"/>.</returns>
        string GetString();

        /// <summary>
        /// Gets an enumerator to enumerate the values in the JSON array represented by this element.
        /// </summary>
        /// <returns>An enumerator to enumerate the values in the JSON array represented by this element.</returns>
        IEnumerable<IJqGridJsonElement> EnumerateArray();
    }
}
