using System.ComponentModel.DataAnnotations;

namespace WebServer.Models {
    public class Actor {
        [Key]
        public int Actor_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
    }
}