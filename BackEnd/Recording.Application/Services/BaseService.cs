using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Recording.Application.IServices;
using Recording.Database;
using Recording.Models.SettingModels;
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
        private AppSettings settings;
        private string _connectionString;

        public Recording_DbContext DbContext
        {
            get;
            private set;
        }
        public BaseService(IOptionsSnapshot<AppSettings> appSettingsAccessor)
        {
            settings = appSettingsAccessor.Value;
            if (String.IsNullOrWhiteSpace(settings.ConnectionStrings.DefaultConnection))
            {
                this.DbContext = new Recording_DbContext();
            }
            else
            {
                this.DbContext = new Recording_DbContext(settings.ConnectionStrings.DefaultConnection);
            }
            dbConnection = this.DbContext.Database.GetDbConnection();
            _connectionString = settings.ConnectionStrings.DefaultConnection;
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
