﻿using Application.Exceptions;
using Application.Validators;
using MediatR;

namespace Application.Commands;
public class DeletePedidoItemCommand(Guid id) : IRequest<Guid>
{
    public Guid Id{ get; set; } = id;

    public void Validate()
    {
        var validator = new DeletePedidoItemValidator();
        var result = validator.Validate(this);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ValidationException(errors);
        }
    }
}
