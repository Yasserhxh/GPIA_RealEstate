namespace ProjectAPI.Api.Application.Projects.UpdateProject
{
    /// <summary>
    /// Validator for the <see cref="UpdateProjectCommand"/> class.
    /// </summary>
    public class UpdateProjectValidator : AbstractValidator<UpdateProjectCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProjectValidator"/> class.
        /// </summary>
        public UpdateProjectValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Project name is required.")
                .MaximumLength(150).WithMessage("Project name must not exceed 150 characters.");

            RuleFor(command => command.Location)
                .NotEmpty().WithMessage("Project location is required.");

            RuleFor(command => command.Type)
                .IsInEnum().WithMessage("Invalid property type.");

            RuleFor(command => command.MinPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Minimum price must be greater than or equal to 0.");

            RuleFor(command => command.MaxPrice)
                .GreaterThanOrEqualTo(command => command.MinPrice).WithMessage("Maximum price must be greater than or equal to the minimum price.");

            RuleFor(command => command.MinSellableSurfaceRange)
                .GreaterThanOrEqualTo(0).WithMessage("Minimum sellable surface range must be greater than or equal to 0.");

            RuleFor(command => command.MaxSellableSurfaceRange)
                .GreaterThanOrEqualTo(command => command.MinSellableSurfaceRange).WithMessage("Maximum sellable surface range must be greater than or equal to the minimum sellable surface range.");
        }
    }
}
