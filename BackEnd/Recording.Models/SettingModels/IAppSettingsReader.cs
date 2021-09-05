using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recording.Models.SettingModels
{
    public interface IAppSettingsReader
    {
        AppSettings AppSettings
        {
            get;
        }
    }

    public class AppSettings
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
        public string MicrosoftHostingLifetime { get; set; }
    }

    public class Connectionstrings
    {
        public string DefaultConnection { get; set; }
    }
    public class AppSettingsReader : IAppSettingsReader
    {

        public IConfiguration Configuration { get; }

        private AppSettings appSettings { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public AppSettingsReader(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.appSettings = new AppSettings();
            Configuration.Bind("AppSettings", appSettings);
        }

        public AppSettings AppSettings
        {
            get
            {
                return appSettings;
            }
        }
    }

}