using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using BlazorWebAssemblyProjectTest.Server.DB;

namespace BlazorWebAssemblyProjectTest.Server.DB
{
    public class SqlServerDbContextFactory : IDesignTimeDbContextFactory<SqlServerDbContext>
    {
        public SqlServerDbContext CreateDbContext(string[] args)
        {
            var connString = "Server=(localdb)\\mssqllocaldb;Database=TestDatabase123;Trusted_Connection=True;";

            var option = new DbContextOptionsBuilder<SqlServerDbContext>().UseSqlServer(connString).Options;

            return new SqlServerDbContext(option);
        }
    }
}
