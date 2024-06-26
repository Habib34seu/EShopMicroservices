﻿namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductComman(Guid Id) : ICommand<DeleteProductResult>;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductComman>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is required");
    }
}

public record DeleteProductResult(bool IsSuccess);
internal class DeleteProductCommandHandler
    (IDocumentSession session)
    : ICommandHandler<DeleteProductComman, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductComman command, CancellationToken cancellationToken)
    {
        
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}
