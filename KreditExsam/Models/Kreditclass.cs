using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditExsam.Models
{
    public class KreditClass
    {
        public int OylikMaosh { get; set; }
        public int KundalikTulov { get; set; }
        public int KredSumma { get; set; }
        public int KredMuddat { get; set; }
        public int KredFoiz { get; set; }

        public KreditClass(int oylikMaosh, int kundalikTulov, int kreditSumm, int kreditMuddat, int kreditFoiz)
        {
            OylikMaosh = oylikMaosh;

            KundalikTulov = kundalikTulov;

            KredSumma = kreditSumm;

            KredMuddat = kreditMuddat;

            KredFoiz = kreditFoiz;
        }
    }
}
