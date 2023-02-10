// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.DocAsCode.Dotnet
{
    using Microsoft.CodeAnalysis;

    internal class FilterVisitor : IFilterVisitor
    {
        private readonly DotnetApiCatalogOptions _options;
        private readonly IFilterVisitor _inner;

        public FilterVisitor(DotnetApiCatalogOptions options, IFilterVisitor inner)
        {
            _options = options;
            _inner = inner;
        }

        public bool CanVisitApi(ISymbol symbol, bool wantProtectedMember, IFilterVisitor outer)
        {
            return _options.ShowApi?.Invoke(symbol) switch
            {
                SymbolShowState.Show => true,
                SymbolShowState.Hide => false,
                _ => _inner.CanVisitApi(symbol, wantProtectedMember, outer),
            };
        }

        public bool CanVisitAttribute(ISymbol symbol, bool wantProtectedMember, IFilterVisitor outer)
        {
            return _options.ShowAttribute?.Invoke(symbol) switch
            {
                SymbolShowState.Show => true,
                SymbolShowState.Hide => false,
                _ => _inner.CanVisitAttribute(symbol, wantProtectedMember, outer),
            };
        }
    }
}
