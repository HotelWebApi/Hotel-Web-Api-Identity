using Domain.Entities.Clients;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.Identity.Client;

namespace Infrastructure.Repositories;

public class ClientRepository : Repository<Client>, IClientInterface
{
    public ClientRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}
