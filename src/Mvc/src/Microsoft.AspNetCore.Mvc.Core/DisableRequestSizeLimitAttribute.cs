﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Mvc
{
    /// <summary>
    /// Disables the request body size limit.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class DisableRequestSizeLimitAttribute : Attribute, IFilterFactory, IOrderedFilter
    {
        /// <summary>
        /// Gets the order value for determining the order of execution of filters. Filters execute in
        /// ascending numeric value of the <see cref="Order"/> property.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Filters are executed in an ordering determined by an ascending sort of the <see cref="Order"/> property.
        /// </para>
        /// <para>
        /// The default Order for this attribute is 900 because it must run before ValidateAntiForgeryTokenAttribute and
        /// after any filter which does authentication or login in order to allow them to behave as expected (ie Unauthenticated or Redirect instead of 400).
        /// </para>
        /// <para>
        /// Look at <see cref="IOrderedFilter.Order"/> for more detailed info.
        /// </para>
        /// </remarks>
        public int Order { get; set; } = 900;

        /// <inheritdoc />
        public bool IsReusable => true;

        /// <inheritdoc />
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var filter = serviceProvider.GetRequiredService<DisableRequestSizeLimitFilter>();
            return filter;
        }
    }
}