using Als.Foundation.Data.Abstractions.EntityFramework;
using ProjectAPI.Domain.Reservations.Entities;

namespace ProjectAPI.Domain.Reservations.Interface;

public interface IReservationRepository : IBaseRepository<Reservation>
{
}
