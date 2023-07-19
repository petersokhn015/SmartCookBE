using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Application.DTO
{
    public class SearchRecipeDTO
    {
        public string QuerySearch { get; set; } = string.Empty;

        public int limit { get; set; }
    }
}
