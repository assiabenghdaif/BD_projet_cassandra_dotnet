
using System.ComponentModel.DataAnnotations;


namespace BD_Projet_v_1_0_0.Models
{
    public class Artists{

        [Key]
        [Display(Name = "Artist ID")]
        public Guid ID { get; set; }
        [Display(Name = "Stage Name")]
        public string Stage_Name { get; set; }
        public string Full_Name { get; set; }
        public string Date_of_Birth { get; set; }
        public string Original_group { get; set; }
        public string Debut { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string Birthplace { get; set; }
        public string Gender { get; set; }
        public IDictionary<string,string> song { get; set; }

        public override string ToString()
    {
        string tt="{";
        foreach (var i in song){
            tt+=i.Key+":"+i.Value+",";

        }
        tt+="}";
        return $"Artist: ID={ID},Stage_Name={Stage_Name},Full_Name={Full_Name},Date_of_Birth={Date_of_Birth},Original_group={Original_group},Debut={Debut},Company={Company},Country={Country},Height={Height},Weight={Weight},Birthplace={Birthplace},Gender={Gender},song={tt}";
    }

    }
}