
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

        public string FindAll(string table){
            return "SELECT * FROM "+ table;
        }

        public string FindBy(string table,string key){
            return key !="song" ? "SELECT * FROM "+table+" WHERE "+key+" = ? ALLOW FILTERING": "SELECT * FROM "+table+" WHERE "+key+" CONTAINS key ? ALLOW FILTERING";
        }

        public string save(string table){
            //ID,Stage_Name,Full_Name,Date_of_Birth,Original_group,Debut,Company,Country,Height,Weight,Birthplace,Gender,song
            return "INSERT INTO "+table +" (ID,Stage_Name,Full_Name,Date_of_Birth,Original_group,Debut,Company,Country,Height,Weight,Birthplace,Gender,song) VALUES(Uuid(),?,?,?,?,?,?,?,?,?,?,?,?)";
        }

        public string deleteById(string table){
            return "DELETE FROM "+table +" where ID=? ";
        }

        public string update(string table, string key){
            return "update "+table+" set "+key+" = ? where ID=?";
        }




            
    }
}