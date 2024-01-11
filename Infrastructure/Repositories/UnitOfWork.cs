
using Infrastructure.Data;
using Infrastructure.Interfaces;
using System;

public class UnitOfWork(ApplicationDbContext dbContext,
                       IStaffInterface staffInterface,
                       IGuestInterface guestInterface,
                       IOrderInterface orderInterface,
                       IOrderStatusInterface orderStatusInterface,
                       IRoomInterface roomInterface,
                       IClientInterface clientInterface,
                       IRoomStatusInterface roomStatusInterface,
                       IOnlineBronInterface onlineBronInterface,
                       IRoomTypeInterface roomTypeInterface) : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public IClientInterface ClientInterface { get; } = clientInterface;

    public IStaffInterface StaffInterface { get; } = staffInterface;

    public IOnlineBronInterface OnlineBronInterface { get; } = onlineBronInterface;

    public IGuestInterface GuestInterface { get; } = guestInterface;

    public IOrderStatusInterface OrderStatusInterface { get; } = orderStatusInterface;

    public IOrderInterface OrderInterface { get; } = orderInterface;

    public IRoomInterface RoomInterface { get; } = roomInterface;

    public IRoomStatusInterface RoomStatusInterface { get; } = roomStatusInterface;

    public IRoomTypeInterface RoomTypeInterface { get; } = roomTypeInterface;

    public void Dispose()
         => GC.SuppressFinalize(this);

    public async Task SaveAsync()
            => await _dbContext.SaveChangesAsync();
}