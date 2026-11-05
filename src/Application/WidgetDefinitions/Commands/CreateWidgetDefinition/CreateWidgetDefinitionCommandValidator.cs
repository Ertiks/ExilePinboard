using Exile_Pinboard.Application.Common.Interfaces;

namespace Exile_Pinboard.Application.WidgetDefinitions.Commands.CreateWidgetDefinition;

public class CreateWidgetDefinitionCommandValidator : AbstractValidator<CreateWidgetDefinitionCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateWidgetDefinitionCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(t => t.Name)
            .NotEmpty().MaximumLength(100);
        RuleFor(t => t.Code)
            .NotEmpty().MaximumLength(100)
            .MustAsync(BeUniqueCode)
                .WithMessage("'{PropertyName}' must be unique.")
                .WithErrorCode("Unique");
        RuleFor(t => t.Description)
            .MaximumLength(500);
    }

    public async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
    {
        return !await _context.WidgetDefinitions
            .AnyAsync(t => t.Code == code, cancellationToken);
    }
}
