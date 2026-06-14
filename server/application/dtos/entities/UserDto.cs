namespace Application.DTOs.Entities;

public sealed record UserDto(Guid Id, string FirstName, string LastName, string Email, int Role);

public sealed record CreateUserDto
{
	public string FirstName { get; init; } = string.Empty;
	public string LastName { get; init; } = string.Empty;
	public string Email { get; init; } = string.Empty;
	public string Password { get; init; } = string.Empty;
	public int Role { get; init; }
}

public sealed record EditUserDto
{
	public Guid Id { get; init; }
	public string FirstName { get; init; } = string.Empty;
	public string LastName { get; init; } = string.Empty;
	public string Email { get; init; } = string.Empty;
	public int Role { get; init; }
}