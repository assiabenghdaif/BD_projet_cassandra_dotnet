using System.Data;

namespace DAL{
    class DAL_DAO : DbConnection{
         
       public List<Artists> Getall()
        {
            List<Artists> artists = new List<Artists>();
            try
            {
                DbConnection connection = new DbConnection();
                Artists artist=new Artists();
                

                var rs = session.Execute("SELECT * FROM artists.artists");
                foreach (var row in rs)
                {
                    artist=new Artists();
                    //ID,Stage_Name,Full_Name,Date_of_Birth,Original_group,Debut,Company,Country,Height,Weight,Birthplace,Gender,song
                    artist.setId(row.GetValue<string>("ID"));
                    artist.setId(row.GetValue<string>("Stage_Name"));
                    artist.setId(row.GetValue<string>("Full_Name"));
                    artist.setId(row.GetValue<string>("Date_of_Birth"));
                    artist.setId(row.GetValue<string>("Original_group"));
                    artist.setId(row.GetValue<string>("Debut"));
                    artist.setId(row.GetValue<string>("Company"));
                    artist.setId(row.GetValue<string>("Debut"));
                    artist.setHeight(row.GetValue<int>("Height"));
                    artist.setWeight(row.GetValue<int>("Weight"));
                    artist.setBirthplace(row.GetValue<string>("Birthplace"));
                    artist.setGender(row.GetValue<string>("Gender"));
                    artist.setId(row.GetValue<string>("song"));
                    
                    artists.Add(artist);
                }
                        

                


                return artists;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
    }
}