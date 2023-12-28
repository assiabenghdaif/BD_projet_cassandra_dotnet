using System.ComponentModel.DataAnnotations;

namespace BD_Projet_v_1_0_0.Models
{
    public class User{
        [Key]
        public Guid id { get; set;}
        public string firstname { get; set;}
        public string lastname { get; set;}
        public string username {get; set;}
        public string password { get; set;}

    }
}