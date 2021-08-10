namespace MyStore.Config
{
    public class WindowsSettings : IDbSettings
    {
        public string Server { get; set; }

        public string Database { get; set; }

        public bool IntegratedSecurity { get; set; }

        public string ConnectionString
        {
            get
            {
                return $"server = {Server}; database = {Database}; integrated security = {IntegratedSecurity}";
            }
        }
    }
}
