using HW2.Data.Configuration;
using HW2.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Data.Context
{
    public class HW2Context :DbContext
    {
        public HW2Context(DbContextOptions<HW2Context> options) : base(options)
        {

        }


        // dbset
        public DbSet<Account> Account { get; set; }
        public DbSet<Transaction> Transaction { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().HasData(
                new Account() { AccountNumber=10001, Balance=1500, Name="John", OpenDate=new DateTime(2010,05,23),CurrencyCode="TRY",IsActive=true, InsertUser="SystemAdmin",InsertDate=new DateTime(2023,07,07) },
                new Account() { AccountNumber=10002, Balance=2500, Name="Jeyn", OpenDate=new DateTime(2023,01,29),CurrencyCode="TRY",IsActive=true, InsertUser="SystemAdmin",InsertDate=new DateTime(2023,08,07) },
                new Account() { AccountNumber=10003, Balance=5200, Name="Tom", OpenDate=new DateTime(2020,02,16),CurrencyCode="TRY",IsActive=true, InsertUser="SystemAdmin",InsertDate=new DateTime(2023,10,07) }
                );
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction() { Id=1, AccountNumber=10001, CreditAmount=10000,DebitAmount=20000,Description="EFT",TransactionDate=new DateTime(2022,10,05),ReferenceNumber="20020",InsertDate=new DateTime(2019,05,29),InsertUser="User" },
                new Transaction() { Id=2, AccountNumber=10001, CreditAmount=5000,DebitAmount=25000,Description="EFT",TransactionDate=new DateTime(2021,02,08),ReferenceNumber="20050",InsertDate=new DateTime(2019,07,29),InsertUser="User" },
                new Transaction() { Id=3, AccountNumber=10002, CreditAmount=12000,DebitAmount=10000,Description="EFT",TransactionDate=new DateTime(2020,01,15),ReferenceNumber="20150",InsertDate=new DateTime(2019,11,22),InsertUser="User" }
                );
        }
    }
}
