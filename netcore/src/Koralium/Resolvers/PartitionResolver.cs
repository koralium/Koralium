/*
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
using Koralium.Models;
using Koralium.SqlParser.Statements;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading.Tasks;

namespace Koralium
{
    public abstract class PartitionResolver
    {
        private static readonly List<ServiceLoction> EmptyServieLocation = new List<ServiceLoction>();

        /// <summary>
        /// Get the partitions for a specific table
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        /// <param name="canHandleMultiplePartitions">True if the caller can handle getting multiple partitions</param>
        /// <param name="sqlTree">The SQL tree that can be modified to give the user the correct partitions</param>
        /// <param name="httpContext">The http context that contains user information etc.</param>
        /// <returns></returns>
        public virtual Task<IImmutableList<Partition>> GetPartitions(bool canHandleMultiplePartitions, PartitionsBuilder partitionsBuilder, HttpContext httpContext, PartitionOptions partitionOptions)
        {
            return Task.FromResult<IImmutableList<Partition>>(ImmutableList.Create<Partition>(partitionsBuilder.NewPartition().Build()));
        }
        
        /// <summary>
        /// If this value is set, it marks how long it should be between calls to Generate partition metadata
        /// </summary>
        public virtual TimeSpan? GenerateMetadataTimespan { get; } = null;

        /// <summary>
        /// This method is called only if GenerateMetadataTimespan is set.
        /// It allows a partition resolver to generate metadata in between calls.
        /// This is useful if the source it self does not have partitions, and the partitions needs to be recalculated in specific intervals.
        /// </summary>
        /// <returns></returns>
        public virtual Task GeneratPartitionMetadata(PartitionOptions partitionOptions)
        {
            return Task.CompletedTask;
        }
    }
}
