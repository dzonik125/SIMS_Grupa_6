using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Filers
{
    class PatientsFilter : TableFilter<Patient>
    {
        public override bool KeywordFilter(Patient entity, string keyword)
        {
            return entity.name.Contains(keyword, StringComparison.InvariantCultureIgnoreCase) ||
                   entity.surname.Contains(keyword, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
