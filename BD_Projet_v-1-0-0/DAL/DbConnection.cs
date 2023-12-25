
using BD_Projet_v_1_0_0.Models;

namespace DAL
{
    class DbConnection
    {
        protected static Cassandra.ISession session;
        static DbConnection()
        {


            var cluster = Cassandra.Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            session = cluster.Connect("artists");
            // session;

        }

        public List<Artists> GetArtists(){
            var getArtists = session.Prepare("SELECT * FROM artists");
        }

        public Artists GetArtist(string id){
            var getArtist = session.Prepare("SELECT * FROM artists WHERE id = ?");
            var row = session.Execute(getArtist.Bind(id)).FirstOrDefault();
            return (Artists)row;
        }

            
    }
}