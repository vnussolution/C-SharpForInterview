using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Learn.AngularJS.DAL
{
    // This class is to enable resiliency 
    public class MyConfiguration : DbConfiguration
    {
        public MyConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}
