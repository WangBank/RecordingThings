using Microsoft.EntityFrameworkCore;
using Recording.Application.IServices;
using Recording.Database;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recording.Application.Services
{
    public class BaseService : IDisposable
    {
        private DbConnection dbConnection = null;
        private string _connectionString = string.Empty;

        public Recording_DbContext DbContext
        {
            get;
            private set;
        }
        public BaseService(string connectionString = null)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                this.DbContext = new Recording_DbContext();
            }
            else
            {
                this.DbContext = new Recording_DbContext(connectionString);
            }
            dbConnection = this.DbContext.Database.GetDbConnection();
            _connectionString = connectionString;
        }

        public void Save()
        {
            this.DbContext.SaveChanges();
        }
        public void Dispose()
        {
            if (this.DbContext != null)
            {
                this.DbContext.Dispose();
                this.DbContext = null;
            }
        }

    }
}
