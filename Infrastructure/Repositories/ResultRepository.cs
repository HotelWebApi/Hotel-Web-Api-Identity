using Domain.Entities.Rooms;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class ResultRepository : Repository<Result>, IResultInterface
{
    public ResultRepository(ApplicationDbContext dbContext) 
        : base(dbContext)
    {
    }
}