using System;
using Microsoft.Extensions.Configuration;

namespace MyStore.Config
{
    public class SettingsReader
    {
        public IDbSettings GetDbSettings()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("AppSettings.json").Build();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                var section = config.GetSection(nameof(WindowsSettings));
                return section.Get<WindowsSettings>();
            }
            else if(Environment.OSVersion.Platform == PlatformID.Unix)
            {
                var section = config.GetSection(nameof(LinuxSettings));
                return section.Get<LinuxSettings>();
            }
            else
            {
                throw new NotSupportedException("Current platform is not supported !");
            }
        }
    }
}