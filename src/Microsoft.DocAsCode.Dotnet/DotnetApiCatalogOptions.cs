// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.CodeAnalysis;

#nullable enable

namespace Microsoft.DocAsCode.Dotnet
{
    /// <summary>
    /// Provides options to be used with <see cref="DotnetApiCatalog.GenerateManagedReferenceYamlFiles(string)(string, DotnetApiCatalogOptions)"/>.
    /// </summary>
    public class DotnetApiCatalogOptions
    {
        /// <summary>
        /// Customizes the namespace, type or attribute to include in the API catalog.
        /// </summary>
        /// <remarks>
        /// Show private or internal symbols are not supported in this version.
        /// </remarks>
        public Func<ISymbol, bool>? ShowSymbol { get; init; }
    }
}
