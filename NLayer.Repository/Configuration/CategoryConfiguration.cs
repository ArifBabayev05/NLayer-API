﻿using System;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;

namespace NLayer.Repository.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x=>x.Id);
            //builder.Property(x => x.Id).UseIdentityColumn(2,2);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            

        }
    }
}

