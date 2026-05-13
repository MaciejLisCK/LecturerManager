using LecturerManager.Domain.Shared.Exceptions;

namespace LecturerManager.Domain.Identity.Exceptions;

public class LoginAlreadyExistsException(string login)
    : DomainException($"Login '{login}' already exists.");
