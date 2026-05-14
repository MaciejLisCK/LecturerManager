using LecturerManager.Domain.Shared.Exceptions;

namespace LecturerManager.Domain.Identity.Exceptions;

public class InvalidCredentialsException()
    : DomainException("Invalid login or password.");