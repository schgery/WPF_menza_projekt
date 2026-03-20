using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_menza_projekt.models
{
    public class vendegnapietkezes
    {
        public vendeg vendeg { get; set; }
        public int vendegid { get; set; }
        public napietkezes napietkezes { get; set; }
        public int napietkezesid { get; set; }
    }
}
