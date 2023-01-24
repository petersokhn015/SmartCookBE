using System.ComponentModel.DataAnnotations;

namespace SmartCook.Domain.DBEntities
{
    public class Preferences
    {
        public int Id { get; set; }
        [MaxLength(80)]
        public string Diet { get; set; } = string.Empty;
        public List<string> Intolerances { get; set; } = new List<string>();
        public List<string> CuisineTypes { get; set; } = new List<string>();
    }
}