using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Microsoft.DocAsCode.Dotnet
{
    /// <summary>
    /// Determines what APIs to include in the API catalog.
    /// </summary>
    public static class SymbolFilter
    {
        /// <summary>
        /// Determines if the symbol should be included in the API catalog.
        /// </summary>
        public static bool ShowSymbol(ISymbol symbol)
        {
            return true;
        }
    }
}
