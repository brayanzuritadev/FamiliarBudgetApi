using Microsoft.EntityFrameworkCore;

namespace FamiliarBudgetApi.DataAccessLayer.ContextDB
{
    public interface IConexionDB
    {
        public void ApplicationDbContext(DbContextOptions options)
        {

        }
    }
}
