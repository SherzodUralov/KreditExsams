using KreditExsam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditExsam
{
    public interface IKreditService
    {
        Task<List<Superclass>> KREDIT_GETS(KreditClass credit);
    }
}
