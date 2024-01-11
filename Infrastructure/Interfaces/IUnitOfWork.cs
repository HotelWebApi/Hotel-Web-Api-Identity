namespace Infrastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IClientInterface ClientInterface { get; }
    IStaffInterface StaffInterface { get; }
    IOnlineBronInterface OnlineBronInterface { get; }
    IGuestInterface GuestInterface { get; }
    IOrderStatusInterface OrderStatusInterface { get; }
    IOrderInterface OrderInterface { get; }
    IRoomInterface RoomInterface { get; }
    IRoomStatusInterface RoomStatusInterface { get; }
    IRoomTypeInterface RoomTypeInterface { get; }

    Task SaveAsync();
}
