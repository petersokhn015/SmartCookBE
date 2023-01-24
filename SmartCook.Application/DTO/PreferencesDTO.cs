using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DTO
{
    public class PreferencesDTO
    {
        public string Diet { get; set; } = string.Empty;
        public List<string> Intolerances { get; set; } = new List<string>();
        public List<string> CuisineTypes { get; set; } = new List<string>();
    }
}
