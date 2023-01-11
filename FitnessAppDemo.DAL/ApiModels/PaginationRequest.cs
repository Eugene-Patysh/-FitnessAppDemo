using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppDemo.Logic.ApiModels
{
    public class PaginationRequest
    {
        public string Query { get; set; }
        public int? Skip { get; set; } = 0;
        public int? Take { get; set; } = 10;
        public string SortBy { get; set; }
        public bool Asc { get; set; } = true;
    }
}
