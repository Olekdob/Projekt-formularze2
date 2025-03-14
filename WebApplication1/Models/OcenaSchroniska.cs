using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;
using System.Drawing;

namespace WebApplication1.Models
{
    public class OcenaSchroniska
    {
        [Key]
        public int IdOceny { get; set; }
        [ForeignKey(nameof(Schronisko.Id))]
        public int IdSchroniska { get; set; }
        public string Opis { get; set; }
        public int Ocena { get; set; }
    }
}
