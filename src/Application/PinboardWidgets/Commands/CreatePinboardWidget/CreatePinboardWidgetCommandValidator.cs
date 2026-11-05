using Exile_Pinboard.Application.Common.Interfaces;

namespace Exile_Pinboard.Application.PinboardWidgets.Commands.CreatePinboardWidget;

public class CreatePinboardWidgetCommandValidator : AbstractValidator<CreatePinboardWidgetCommand>
{

    public CreatePinboardWidgetCommandValidator(IApplicationDbContext context)
    {
        RuleFor(w => w.Name)
            .MaximumLength(50);

        RuleFor(w => w.WidgetDefinitionId)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(0)
            .MustAsync((id, ct) =>
                context.WidgetDefinitions.AnyAsync(w => w.Id == id, ct))
            .WithMessage("The widget definition does not exist.");

        // #TODO : Ajouter Rule PinboardId

        RuleFor(w => w.X)
            .Must(double.IsFinite)
            .WithMessage("{PropertyName} must be a finite number.");
        RuleFor(w => w.Y)
            .Must(double.IsFinite)
            .WithMessage("{PropertyName} must be a finite number.");
        RuleFor(w => w.Height)
            .Must(h => double.IsFinite(h) && h > 0)
            .WithMessage("{PropertyName} must be a finite number greater than zero.");
        RuleFor(w => w.Width)
            .Must(w => double.IsFinite(w) && w > 0)
            .WithMessage("{PropertyName} must be a finite number greater than zero.");
    }
}

