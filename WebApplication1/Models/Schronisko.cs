using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace WebApplication1.Models
{
    public class Schronisko
    {
        [Key]
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Miejscowosc { get; set; }
        public int Ocena { get; set; }
        public string Zdjecie { get; set; }
    }
}
