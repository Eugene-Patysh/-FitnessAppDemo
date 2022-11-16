using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppDemo.BLL.Models
{
    public class ProductDb
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TreatingTypeId { get; set; }
        public TreatingTypeDb TreatingType { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
