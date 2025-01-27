﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.DocAsCode.Build.ManagedReference
{
    using System;
    using System.Collections.Generic;
    using System.Composition;
    using System.Collections.Immutable;

    using Microsoft.DocAsCode.Build.Common;
    using Microsoft.DocAsCode.Dotnet.ManagedReference;
    using Microsoft.DocAsCode.Plugins;

    [Export(nameof(ManagedReferenceDocumentProcessor), typeof(IDocumentBuildStep))]
    public class ValidateManagedReferenceDocumentMetadata : BaseDocumentBuildStep
    {
        public override string Name => nameof(ValidateManagedReferenceDocumentMetadata);

        public override int BuildOrder => 1;

        public override void Build(FileModel model, IHostService host)
        {
            if (!host.HasMetadataValidation)
            {
                return;
            }
            switch (model.Type)
            {
                case DocumentType.Article:
                    break;
                case DocumentType.Overwrite:
                    foreach (var item in (List<OverwriteDocumentModel>)model.Content)
                    {
                        host.ValidateInputMetadata(model.OriginalFileAndType.File, item.ConvertTo<ItemViewModel>().Metadata.ToImmutableDictionary());
                    }
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
