﻿using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Model.SqlServerContext
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext()
        {

        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set;}
        
    }
}
