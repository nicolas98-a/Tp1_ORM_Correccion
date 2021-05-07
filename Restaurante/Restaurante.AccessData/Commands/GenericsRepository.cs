using Restaurante.Domain.Commands;

namespace Restaurante.AccessData.Commands
{
    public class GenericsRepository : IGenericsRepository
    {
        public void Add<T>(T entity) where T : class
        {
            using (RestauranteContext _context = new RestauranteContext())
            {
                _context.Add(entity);
                _context.SaveChanges();
            }
        }
    }
}
