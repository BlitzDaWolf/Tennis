﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tenis_opdracht.Data.Model;

namespace Tenis_opdracht.DAL.Configuration
{
    public class MemberRoleConfiguration : BaseEntityTypeConfiguration<MemberRole>
    {
        public MemberRoleConfiguration() : base("tblMemberRoles") { }

        public override void Configure(EntityTypeBuilder<MemberRole> e)
        {
            e.HasKey(c => c.Id);
            e.Property(c => c.Id).ValueGeneratedOnAdd();

            e.Property(c => c.StartDate).IsRequired().HasColumnType("DATE");
            e.Property(c => c.EndDate).HasColumnType("DATE");

            e.HasIndex(c => new { c.MemberId, c.RoleId, c.StartDate, c.EndDate }).IsUnique();

            e.HasOne(c => c.Role).WithMany().HasForeignKey(k => k.RoleId);

            base.Configure(e);
        }
    }
}
