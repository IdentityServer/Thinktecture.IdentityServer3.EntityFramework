﻿/*
 * Copyright 2014 Dominick Baier, Brock Allen
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System.Data.Entity;
using IdentityServer3.EntityFramework.Entities;

namespace IdentityServer3.EntityFramework
{
    public class ScopeConfigurationDbContext : BaseDbContext, IScopeConfigurationDbContext
    {
        public ScopeConfigurationDbContext()
            : this(EfConstants.ConnectionName)
        {
        }

        public ScopeConfigurationDbContext(string connectionString)
            : base(connectionString)
        {
        }
        
        public ScopeConfigurationDbContext(string connectionString, string schema)
            : base(connectionString, schema)
        {
        }

        protected override void ConfigureChildCollections()
        {
            this.RegisterScopeChildTablesForDelete<Scope>();
        }

        public DbSet<Scope> Scopes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureScopes(Schema);
        }
    }
}
