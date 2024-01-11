using Domain.Entities.Rooms;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class OnlineBronRepository : Repository<OnlineBron>, IOnlineBronInterface
{
    public OnlineBronRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
