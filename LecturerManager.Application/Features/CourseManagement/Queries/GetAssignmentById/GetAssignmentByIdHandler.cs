using LecturerManager.Application.Features.CourseManagement.DTOs;
using LecturerManager.Application.Features.CourseManagement.Mappings;
using LecturerManager.Domain.CourseManagement.Interfaces;
using MediatR;

namespace LecturerManager.Application.Features.CourseManagement.Queries.GetAssignmentById;

public class GetAssignmentByIdHandler(ICourseRepository courseRepository) : IRequestHandler<GetAssignmentByIdQuery, AssignmentDetailDto?>
{
    public async Task<AssignmentDetailDto?> Handle(GetAssignmentByIdQuery request, CancellationToken cancellationToken)
    {
        var assignment = await courseRepository.GetAssignmentByIdAsync(request.CourseId, request.AssignmentId, cancellationToken);
        return assignment?.ToDetailDto();
    }
}
