using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppDemo.Logic.ApiModels
{
    public class PaginationResponse<T>
    {
        public int Total { get; set; }
        public T[] Values { get; set; }
    }
}
