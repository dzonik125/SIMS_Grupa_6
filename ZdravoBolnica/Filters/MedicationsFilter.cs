using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Filters
{
    class MedicationsFilter : Filers.TableFilter<Medication>
    {
        public override bool KeywordFilter(Medication entity, string keyword)
        {
            return entity.name.Contains(keyword, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
