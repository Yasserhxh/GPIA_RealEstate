﻿using MediatR;
using ProjectAPI.Api.Application.Common.Models;

namespace ProjectAPI.Api.Application.Units.GetUnitsByProjectId;

/// <summary>
/// Query to retrieve units by project ID.
/// </summary>
public class GetUnitsByProjectIdQuery : IRequest<PaginatedResponse<UnitResponse>>
{
    /// <summary>
    /// The ID of the project for which units are to be retrieved.
    /// </summary>
    public Guid ProjectId { get; set; }

    /// <summary>
    /// The page number for pagination.
    /// </summary>
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// The number of units per page for pagination.
    /// </summary>
    public int PageSize { get; set; } = 10;
}
