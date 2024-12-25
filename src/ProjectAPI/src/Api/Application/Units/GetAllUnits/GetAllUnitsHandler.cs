﻿using ProjectAPI.Api.Application.Common.Models;
using ProjectAPI.Domain.Immeubles.Interfaces;
using System.Linq.Expressions;
using Unit = ProjectAPI.Domain.Immeubles.Entities.Unit;

namespace ProjectAPI.Api.Application.Units.GetAllUnits;

/// <summary>
/// Handler to retrieve all units with optional filters and pagination.
/// </summary>
public class GetAllUnitsHandler : IRequestHandler<GetAllUnitsQuery, PaginatedResponse<UnitResponse>>
{
    private readonly IUnitRepository _unitRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllUnitsHandler"/> class.
    /// </summary>
    /// <param name="unitRepository">The repository to access unit data.</param>
    public GetAllUnitsHandler(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    /// <summary>
    /// Handles the query to retrieve all units based on the specified filters and pagination parameters.
    /// </summary>
    /// <param name="request">The query containing filter and pagination parameters.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A paginated response containing the filtered units.</returns>
    public async Task<PaginatedResponse<UnitResponse>> Handle(GetAllUnitsQuery request, CancellationToken cancellationToken)
    {
        // Build dynamic predicate for filtering units
        Expression<Func<Unit, bool>> predicate = unit =>
            (string.IsNullOrEmpty(request.Floor) || unit.Floor.Contains(request.Floor)) &&
            (!request.MinBedrooms.HasValue || unit.NumberOfBedrooms >= request.MinBedrooms) &&
            (!request.MaxBedrooms.HasValue || unit.NumberOfBedrooms <= request.MaxBedrooms) &&
            (!request.MinSurface.HasValue || unit.ApartmentSurface >= request.MinSurface) &&
            (!request.MaxSurface.HasValue || unit.ApartmentSurface <= request.MaxSurface) &&
            (!request.MinPrice.HasValue || unit.LatestPrice >= request.MinPrice) &&
            (!request.MaxPrice.HasValue || unit.LatestPrice <= request.MaxPrice);

        // Fetch filtered units from the repository
        var units = (await _unitRepository.Find(predicate))
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(u => new UnitResponse
            {
                Id = u.Id,
                Floor = u.Floor,
                UnitNumber = u.UnitNumber,
                NumberOfBedrooms = u.NumberOfBedrooms,
                NumberOfBathrooms = u.NumberOfBathrooms,
                ApartmentSurface = u.ApartmentSurface,
                BalconySurface = u.BalconySurface,
                TerraceSurface = u.TerraceSurface,
                GardenSurface = u.GardenSurface,
                View = u.View,
                Orientation = u.Orientation,
                TotalSurface = u.TotalSurface,
                SaleableValue = u.SaleableValue,
                SaleableValue1 = u.SaleableValue1,
                PriceSaleableValue = u.PriceSaleableValue,
                PriceSaleableValue1 = u.PriceSaleableValue1,
                LatestPrice = u.LatestPrice
            }).ToList();

        // Calculate the total number of items for pagination
        var totalItems = units.Count;

        // Return the paginated response
        return new PaginatedResponse<UnitResponse>(units, request.PageNumber, request.PageSize, totalItems);
    }
}
