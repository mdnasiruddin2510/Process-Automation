﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context.Interfaces;

namespace Data.Context.Config
{
    public class BaseDbContext : DbContext, IDbContext
    {
        public BaseDbContext(string connectionStringName, int? currentUserId = null)
            : base(connectionStringName)
        {
            CurrentUserId = currentUserId;
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public int? CurrentUserId { get; private set; }
    }
}
