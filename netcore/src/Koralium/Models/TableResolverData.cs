﻿/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using Koralium.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Koralium.Models
{
    /// <summary>
    /// This class contains extra data that the table resolver requires
    /// </summary>
    class TableResolverData
    {
        public HttpContext HttpContext { get; }

        public IServiceProvider ServiceProvider { get; }

        public IReadOnlyDictionary<string, object> ExtraData { get; }

        public ICustomMetadataStore CustomMetadataStore { get; }

        public TableResolverData(
            HttpContext httpContext, 
            IServiceProvider serviceProvider, 
            IReadOnlyDictionary<string, object> extraData,
            ICustomMetadataStore customMetadataStore)
        {
            HttpContext = httpContext;
            ServiceProvider = serviceProvider;
            ExtraData = extraData;
            CustomMetadataStore = customMetadataStore;
        }
    }
}
