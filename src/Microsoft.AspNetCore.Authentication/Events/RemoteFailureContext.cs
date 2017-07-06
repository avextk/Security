// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Authentication
{
    /// <summary>
    /// Provides failure context information to handler providers.
    /// </summary>
    public class RemoteFailureContext : HandleRequestContext<RemoteAuthenticationOptions>
    {
        [Obsolete]
        public RemoteFailureContext(
            HttpContext context,
            AuthenticationScheme scheme,
            RemoteAuthenticationOptions options,
            Exception failure)
            : base(context, scheme, options)
        {
            Failure = failure;
        }

        public RemoteFailureContext(
            HttpContext context,
            AuthenticationScheme scheme,
            RemoteAuthenticationOptions options)
            : base(context, scheme, options)
        {
        }

        /// <summary>
        /// User friendly error message for the error.
        /// </summary>
        public Exception Failure
        {
            get => Error?.Failure;
            set => Error = value == null ? new AuthenticationError(value, Properties) : null;
        }

        /// <summary>
        /// Additional state values for the authentication session.
        /// </summary>
        public AuthenticationProperties Properties => Error?.Properties;

        /// <summary>
        /// Holds error information from the authentication.
        /// </summary>
        public AuthenticationError Error { get; set; }
    }
}
