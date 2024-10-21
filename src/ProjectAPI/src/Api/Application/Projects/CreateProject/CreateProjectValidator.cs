namespace ProjectAPI.Api.Application.Projects.CreateProject
{
    /// <summary>
    /// Validator for the <see cref="CreateProjectCommand"/> class.
    /// </summary>
    public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProjectValidator"/> class.
        /// </summary>
        public CreateProjectValidator()
        {
            // Validation rule for Name
            RuleFor(project => project.Name)
                .NotEmpty().WithMessage("Project name is required.")
                .MaximumLength(150).WithMessage("Project name must not exceed 150 characters.");

            // Validation rule for Location
            RuleFor(project => project.Location)
                .NotEmpty().WithMessage("Project location is required.");

            // Validation rule for Type
            RuleFor(project => project.Type)
                .NotEmpty().WithMessage("Project type is required.")
                .MaximumLength(50).WithMessage("Project type must not exceed 50 characters.");

            // Validation rule for MinPrice
            RuleFor(project => project.MinPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Minimum price must be greater than or equal to 0.");

            // Validation rule for MaxPrice
            RuleFor(project => project.MaxPrice)
                .GreaterThanOrEqualTo(project => project.MinPrice).WithMessage("Maximum price must be greater than or equal to the minimum price.");

            // Validation rule for Images
            RuleFor(project => project.Images)
                .NotEmpty().WithMessage("Project images are required.");

            // Validation rule for Latitude
            RuleFor(project => project.Latitude)
                .NotEmpty().WithMessage("Latitude is required.");

            // Validation rule for Longitude
            RuleFor(project => project.Longitude)
                .NotEmpty().WithMessage("Longitude is required.");

            // Validation rule for NumberOfUnits
            RuleFor(project => project.NumberOfUnits)
                .GreaterThanOrEqualTo(0).WithMessage("Number of units must be greater than or equal to 0.");

            // Validation rules for Min and Max Sellable Surface Range
            RuleFor(project => project.MinSellableSurfaceRange)
                .GreaterThan(0).WithMessage("Minimum sellable surface range must be greater than 0.");

            RuleFor(project => project.MaxSellableSurfaceRange)
                .GreaterThan(project => project.MinSellableSurfaceRange).WithMessage("Maximum sellable surface range must be greater than minimum sellable surface range.");
        }
    }
}
