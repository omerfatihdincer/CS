using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CS.EntityFrameworkCore.EntityFrameworkCore
{
    public class CsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CSDbContext> builder, string connectionString)
        {
            builder
               .UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CSDbContext> builder, DbConnection connection)
        {
            builder
                .UseSqlServer(connection);
        }
    }
}
