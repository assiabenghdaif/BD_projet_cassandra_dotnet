
namespace DAL
{
class DbConnection
{
    protected static Cassandra.ISession session;
    static DbConnection()
    {


        var cluster = Cassandra.Cluster.Builder().AddContactPoint("127.0.0.1").Build();
        session = cluster.Connect();
        // session;

    }
}
}