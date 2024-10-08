using AuthenticationAPI.Domain.ApplicationUser.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;

namespace AuthenticationAPI.Api.Application.Users.Register;

/// <summary>
/// Handles the registration command and processes user registration.
/// </summary>
public class RegisterHandler : IRequestHandler<RegisterCommand, string>
{
    private readonly UserManager<User> _userManager;

    /// <summary>
    /// Constructor for RegisterHandler.
    /// </summary>
    /// <param name="userManager">The UserManager for managing user-related operations.</param>
    public RegisterHandler(UserManager<User> userManager)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    /// <summary>
    /// Handles the registration command and processes user registration.
    /// </summary>
    /// <param name="request">The RegisterCommand request.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A string indicating the result of the registration operation.</returns>
    public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // Adapt the RegisterCommand to a User entity
        var user = request.Adapt<User>();

        // Create the user with the specified password
        var result = await _userManager.CreateAsync(user, request.Password);

        // Check if user creation was successful
        if (result.Succeeded)
        {
            // Add roles to the user 
            foreach (string role in request.Roles)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            // Return success message
            return user.Id;
        }
        else
        {
            // Throw an exception with error details if user creation fails ex:user exist already
            var validationFailures = result.Errors.Select(error => new ValidationFailure(error.Code, error.Description));
            throw new Common.Exceptions.ValidationException(validationFailures);
        }
    }
}