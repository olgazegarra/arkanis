using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanis.Repositories
{
    public class MultipleDbConfiguration : DbConfiguration
    {
        #region Constructors 

        public MultipleDbConfiguration()
        {
            SetProviderServices(MySqlProviderInvariantName.ProviderName, new MySqlProviderServices());
        }

        #endregion Constructors

        #region Public methods 

        public static DbConnection GetMySqlConnection(string connectionString)
        {
            var connectionFactory = new MySqlConnectionFactory();

            return connectionFactory.CreateConnection(connectionString);
        }

        #endregion Public methods
    }
}
