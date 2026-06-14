using Application.Common.Interfaces.Auth;
using Application.Common.Interfaces.Services.CRUD;
using Application.Common.Results;
using Application.DTOs.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;

namespace Application.Features.Auth.Register;

public sealed class RegisterUserHandler(
    IUserService userService,
    IUserRepository userRepository
) : ICommandHandler<RegisterUserCommand, Result>
{
    public async Task<Result> HandleAsync(RegisterUserCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            if (await userRepository.IsUserExistByEmailAsync(command.Email))
            {
                return Result.Failure("Email already in use.", ResultStatus.Failure);
            }

            var dto = new CreateUserDto
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password,
                Role = (int)command.Role
            };

            await userService.CreateAsync(dto);
            return Result.Success("User registered successfully.");
        }
        catch (RepositoryException e)
        {
            return Result.Failure(e.Message, ResultStatus.Failure);
        }
    }
}