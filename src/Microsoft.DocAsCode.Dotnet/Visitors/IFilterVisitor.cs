﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.DocAsCode.Dotnet
{
    using Microsoft.CodeAnalysis;

    internal interface IFilterVisitor
    {
        bool CanVisitApi(ISymbol symbol, bool wantProtectedMember = true, IFilterVisitor outer = null);

        bool CanVisitAttribute(ISymbol symbol, bool wantProtectedMember = true, IFilterVisitor outer = null);
    }
}
