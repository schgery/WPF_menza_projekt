using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_menza_projekt.models
{
    public class napietkezes
    {
        public int Id { get; set; }
        public DateOnly datum { get; set; }
        public leves leves { get; set; }
        public int levesid { get; set; }
        public foetel foetel { get; set; }
        public int foetelid { get; set; }
        public desszert? desszert { get; set; }
        public int? desszertid { get; set; }
    }
}
