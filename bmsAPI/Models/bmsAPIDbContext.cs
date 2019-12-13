using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace bmsAPI.Models
{
    public class bmsAPIDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankBalance> BankBalances { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<CusAccountType> CusAccountTypes { get; set; }
        public DbSet<CusTransection> CusTransections { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmpSalary> EmpSalaries { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<MangrTransection> MangrTransections { get; set; }
        public DbSet<ManNoticeBoard> ManNoticeBoards { get; set; }
        public DbSet<ManSalary> ManSalaries { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<NewUserReg> NewUserRegs { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardStatus> CardStatuses { get; set; }
        

    }
}