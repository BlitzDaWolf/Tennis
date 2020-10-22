using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tenis_opdracht.Data.Model.Interface;

namespace Tenis_opdracht.DAL.Configuration
{
    public abstract class BaseEntityTypeConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : IIsDeleted
    {
        public string TableName { get; set; }

        public BaseEntityTypeConfiguration(string TableName)
        {
            this.TableName = TableName;
        }

        public virtual void Configure(EntityTypeBuilder<TBase> e)
        {
            e.HasQueryFilter(p => !p.IsDeleted);
            e.Property(c => c.IsDeleted).HasDefaultValue(false);

            e.ToTable(TableName);
        }
    }
}
