using FamiliarBudgetApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamiliarBudgetApi.Data.DataAccess
{
    public interface IFamilyDAO
    {
        public Family GetFamily(string familyCode);

        public bool InsertFamily(Family family);
    }
}
