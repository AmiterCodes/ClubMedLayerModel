using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMedDAL
{
    class SQLException : Exception
    {
        public SQLException() : base("SQL Error")
        {

        }
    }
}
