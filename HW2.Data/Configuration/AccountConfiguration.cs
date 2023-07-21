using HW2.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Data.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.AccountNumber).IsRequired().ValueGeneratedNever();
            builder.HasIndex(x => x.AccountNumber).IsUnique();
            builder.HasKey(x => x.AccountNumber);

            builder.Property(x => x.InsertUser).IsRequired().HasMaxLength(50);
            builder.Property(x => x.InsertDate).IsRequired();

            builder.Property(x => x.CurrencyCode).IsRequired().HasMaxLength(4);
            builder.Property(x => x.Balance).IsRequired().HasPrecision(15, 4).HasDefaultValue(0);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.OpenDate).IsRequired();

            builder.HasMany(x => x.Transactions)
                .WithOne(x => x.Account)
                .HasForeignKey(x => x.AccountNumber)
                .IsRequired(true);
        }
    }
}
