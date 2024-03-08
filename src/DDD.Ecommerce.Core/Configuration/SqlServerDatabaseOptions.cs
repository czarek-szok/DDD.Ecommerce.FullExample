namespace DDD.Ecommerce.Core.Configuration
{
    public class SqlServerDatabaseOptions
    {
        public string Cluster { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Credentials for user who has permissions to modify objects in database. Should be used to update database schema.
        /// </summary>
        public CredentialsSettings DDL { get; set; } = new CredentialsSettings();

        /// <summary>
        /// Credentials for user who has permissions to manage data. Should be used in running application.
        /// </summary>
        public CredentialsSettings DML { get; set; } = new CredentialsSettings();

        public string ConnectionString => GetConnectionString(DML);

        public string DDLConnectionString => GetConnectionString(DDL);

        private string GetConnectionString(CredentialsSettings credentials)
        {
            if (string.IsNullOrWhiteSpace(credentials.User))
            {
                return $"Server={Cluster};Database={Name};Trusted_Connection=True;ConnectRetryCount=0";
            }
            else
            {
                return $"Server={Cluster};Database={Name};User ID={credentials.User};Password={credentials.Password};";
            }
        }
    }
}
