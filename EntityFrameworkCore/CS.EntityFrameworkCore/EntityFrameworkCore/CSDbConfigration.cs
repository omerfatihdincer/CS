using System;
using System.Collections.Generic;
using System.Text;

namespace CS.EntityFrameworkCore.EntityFrameworkCore
{
    public class CSDbConfigration
    {
        private static string ConnectionString { get; set; }
        public CSDbConfigration(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public CSDbConfigration()
        {
            
        }

        public string GetConnectionString()
        {
            return ConnectionString;
        }
    }
}
