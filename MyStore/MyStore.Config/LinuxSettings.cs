namespace MyStore.Config
{
    public class LinuxSettings : IDbSettings
    {
        public string Server { get; set; }

        public string Database { get; set; }

        public string UID { get; set; }

        public string PWD { get; set; }

        public string ConnectionString
        {
            get
            {
                return $"server = {Server}; database = {Database}; UID = {UID}; PWD = {PWD}";
            }
        }
    }
}
