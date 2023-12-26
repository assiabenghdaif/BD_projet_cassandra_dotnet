using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using BD_Projet_v_1_0_0.Models;
using Cassandra.Data.Linq;

namespace DAL{
    class DAL_DAO : DbConnection{
        DbConnection connection;
        public DAL_DAO(){
            this.connection = new DbConnection();
        }
         
       public List<Artists> Getall(string table)
        {
            List<Artists> artists = new List<Artists>();
            try
            {
                
                Artists artist;
                var rs = session.Execute(FindAll(table));
                foreach (var row in rs)
                {
                    artist=new Artists(){
                        ID=row.GetValue<Guid>("id"),
                        Stage_Name=row.GetValue<string>("stage_name"),
                        Full_Name=row.GetValue<string>("full_name"),
                        Date_of_Birth=row.GetValue<string>("date_of_birth"),
                        Original_group=row.GetValue<string>("original_group"),
                        Debut=row.GetValue<string>("debut"),
                        Company=row.GetValue<string>("company"),
                        Country=row.GetValue<string>("country"),
                        Height=row.IsNull("height") ? (int?)null : row.GetValue<int>("height"),
                        Weight=row.IsNull("weight") ? (int?)null : row.GetValue<int>("weight"),
                        Birthplace=row.GetValue<string>("birthplace"),
                        Gender=row.GetValue<string>("gender"),
                        song=row.GetValue<IDictionary<string,string>>("song")
                        
                    };
                    artists.Add(artist);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return artists;
        }

        public void GetBy(in string table,in string key, in string value, out Artists artist,out List<Artists> artists){
            var query=session.Prepare(FindBy(table,key));
            artist = null;
            artists = new List<Artists>();
            if (key=="id" ) {
                Guid guidValue = Guid.Parse(value);
                var row =session.Execute(query.Bind(guidValue)).FirstOrDefault();
                artist=new Artists(){
                    ID=row.GetValue<Guid>("id"),
                    Stage_Name=row.GetValue<string>("stage_name"),
                    Full_Name=row.GetValue<string>("full_name"),
                    Date_of_Birth=row.GetValue<string>("date_of_birth"),
                    Original_group=row.GetValue<string>("original_group"),
                    Debut=row.GetValue<string>("debut"),
                    Company=row.GetValue<string>("company"),
                    Country=row.GetValue<string>("country"),
                    Height=row.IsNull("height") ? (int?)null : row.GetValue<int>("height"),
                    Weight=row.IsNull("weight") ? (int?)null : row.GetValue<int>("weight"),
                    Birthplace=row.GetValue<string>("birthplace"),
                    Gender=row.GetValue<string>("gender"),
                    song=row.GetValue<IDictionary<string,string>>("song")                
                };
            }
            else{
                var results =session.Execute(query.Bind(value));
                Artists artists1;
                foreach (var rs in results)
                {
                    artists1=new Artists(){
                        ID=rs.GetValue<Guid>("id"),
                        Stage_Name=rs.GetValue<string>("stage_name"),
                        Full_Name=rs.GetValue<string>("full_name"),
                        Date_of_Birth=rs.GetValue<string>("date_of_birth"),
                        Original_group=rs.GetValue<string>("original_group"),
                        Debut=rs.GetValue<string>("debut"),
                        Company=rs.GetValue<string>("company"),
                        Country=rs.GetValue<string>("country"),
                        Height=rs.IsNull("height") ? (int?)null : rs.GetValue<int>("height"),
                        Weight=rs.IsNull("weight") ? (int?)null : rs.GetValue<int>("weight"),
                        Birthplace=rs.GetValue<string>("birthplace"),
                        Gender=rs.GetValue<string>("gender"),
                        song=rs.GetValue<IDictionary<string,string>>("song")                
                    };
                    artists.Add(artists1);
                }
            }
            
            
            
        }

        public bool insert(string table,Artists artists){
            var prepare=session.Prepare(save(table));
            var row = session.Execute(prepare.Bind(artists.Stage_Name,artists.Full_Name,artists.Date_of_Birth,artists.Original_group,
            artists.Debut,artists.Company,artists.Country,artists.Height,artists.Weight,artists.Birthplace,artists.Gender,artists.song));
            return row==null ? false : true;
        }

       public bool delete(string table,Guid id){
        var query = session.Prepare(deleteById(table));
        var row = session.Execute(query.Bind(id));
        return row==null ? false : true;
       } 

       public bool update(string table,string key, string value,Guid id){
        var query = session.Prepare(update(table,key));
        var row = session.Execute(query.Bind(value,id));
        return row==null ? false : true;
       }
    }
}