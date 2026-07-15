using FluentValidation;

namespace Hypex.Application.Commerce;
public class CreateReviewRequestValidator : AbstractValidator<CreateReviewRequest>
{ public CreateReviewRequestValidator() { RuleFor(x => x.Rating).InclusiveBetween(1, 5); RuleFor(x => x.Comment).MaximumLength(2000); } }
public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{ public CreateOrderRequestValidator() { RuleFor(x => x.ContactName).NotEmpty().MaximumLength(200); RuleFor(x => x.ContactPhone).NotEmpty().MaximumLength(40); RuleFor(x => x.ShippingCity).NotEmpty().MaximumLength(120); RuleFor(x => x.ShippingAddress).NotEmpty().MaximumLength(500); RuleFor(x => x.Items).NotEmpty(); } }
public class ProductUpsertRequestValidator : AbstractValidator<ProductUpsertRequest>
{
    public ProductUpsertRequestValidator()
    {
        RuleFor(x => x.Slug).NotEmpty().MaximumLength(160).Matches("^[a-z0-9]+(?:-[a-z0-9]+)*$").WithMessage("Slug must be lowercase letters, digits and single hyphens.");
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CategoryId).GreaterThan(0);
        RuleFor(x => x.BrandId).GreaterThan(0);
        RuleFor(x => x.Translations).NotEmpty().WithMessage("At least one translation is required.");
        RuleForEach(x => x.Translations).ChildRules(t => { t.RuleFor(x => x.Lang).NotEmpty(); t.RuleFor(x => x.Name).NotEmpty().MaximumLength(200); t.RuleFor(x => x.Description).MaximumLength(4000); });
        RuleForEach(x => x.Attributes).ChildRules(a => { a.RuleFor(x => x.Lang).NotEmpty(); a.RuleFor(x => x.Key).NotEmpty().MaximumLength(60); a.RuleFor(x => x.Label).NotEmpty().MaximumLength(120); a.RuleFor(x => x.Value).NotEmpty().MaximumLength(200); });
    }
}
