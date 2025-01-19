using Microsoft.AspNetCore.Identity;
using ProjectAPI.Api.Application.Common.Exceptions;
using ProjectAPI.Domain.Immeubles.Interfaces;
using ProjectAPI.Domain.Reservations.Entities;
using ProjectAPI.Domain.Reservations.Interface;
using ProjectAPI.Domain.Users.Entities;

namespace ProjectAPI.Api.Application.Reservations.CreateReservation
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, CreateReservationResponse>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly UserManager<User> _userManager;

        public CreateReservationHandler(
            IReservationRepository reservationRepository,
            IUnitRepository unitRepository,
            UserManager<User> userManager)
        {
            _reservationRepository = reservationRepository;
            _unitRepository = unitRepository;
            _userManager = userManager;
        }

        public async Task<CreateReservationResponse> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            // Validate Unit
            var unit = await _unitRepository.GetByIDAsync(request.UnitId)
                ?? throw new NotFoundException($"Unit with ID {request.UnitId} not found.");

            // Validate Agent
            var agent = await _userManager.FindByIdAsync(request.AgentId)
                ?? throw new NotFoundException($"Agent with ID {request.AgentId} not found.");

            // If BuyerId is provided, fetch the user
            User? buyer = null;
            if (!string.IsNullOrEmpty(request.BuyerId))
            {
                buyer = await _userManager.FindByIdAsync(request.BuyerId)
                    ?? throw new NotFoundException($"Buyer with ID {request.BuyerId} not found.");
            }

            // Create Reservation
            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                BuyerId = buyer?.Id,
                Name = request.Name ?? buyer?.FirstName,
                LastName = request.LastName ?? buyer?.LastName,
                CIN = request.CIN,
                Email = request.Email ?? buyer?.Email,
                PhoneNumber = request.PhoneNumber ?? buyer?.PhoneNumber,
                UnitId = request.UnitId,
                AgentId = request.AgentId,
                TotalPropertyPrice = request.TotalPropertyPrice,
                ReservationAmount = request.ReservationAmount,
                ReservationDate = DateTime.UtcNow,
                IsUnderConstruction = request.IsUnderConstruction,
                UnitDetails = $"{unit.UnitNumber} - {unit.ApartmentSurface}m²",
            };

            await _reservationRepository.InsertAsync(reservation);
            await _reservationRepository.SaveAsync();

            return new CreateReservationResponse
            {
                ReservationId = reservation.Id,
                Message = "Reservation created successfully."
            };
        }
    }
}
