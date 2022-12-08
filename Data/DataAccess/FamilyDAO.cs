using FamiliarBudgetApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamiliarBudgetApi.Data.DataAccess
{
    public class FamilyDAO : IFamilyDAO
    {
        private readonly ApplicationDbContext context;

        public FamilyDAO(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Family GetFamily(string familyCode)
        {
            return context.Family.FirstOrDefault(x => x.FamilyCode == familyCode);
        }

        public bool InsertFamily(Family family)
        {
            context.Add(family);
            context.SaveChanges();
            return true;
        }
    }
}
