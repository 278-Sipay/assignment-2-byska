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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.InsertUser).IsRequired().HasMaxLength(50);
            builder.Property(x => x.InsertDate).IsRequired();

            builder.Property(x => x.TransactionDate).IsRequired();
            builder.Property(x => x.ReferenceNumber).IsRequired();
            builder.Property(x => x.AccountNumber).IsRequired();
            builder.Property(x => x.CreditAmount).IsRequired().HasPrecision(15, 4).HasDefaultValue(0);
            builder.Property(x => x.DebitAmount).IsRequired().HasPrecision(15, 4).HasMaxLength(0);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x => x.ReferenceNumber).IsRequired().HasMaxLength(50);

            builder.HasIndex(x => x.AccountNumber);
            builder.HasIndex(x => x.ReferenceNumber);
        }
    }
}
