using FamiliarBudgetApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamiliarBudgetApi.DataAccessLayer.DAO
{
    public interface IFamilyDAO
    {
        public Family GetFamily(string familyCode);

        public bool InsertFamily(Family family);
    }
}
