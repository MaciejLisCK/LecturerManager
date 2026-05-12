using LecturerManager.Application.Features.CourseManagement.DTOs;
using LecturerManager.Domain.CourseManagement.Entities;

namespace LecturerManager.Application.Features.CourseManagement.Mappings;

internal static class CourseMappingExtensions
{
    internal static CourseDto ToDto(this Course course) => new(
        course.Id,
        course.Name.Value,
        [.. course.Assignments.Select(a => a.ToDto())]
    );

    internal static AssignmentDto ToDto(this Assignment assignment) => new(
        assignment.Id,
        assignment.Name.Value
    );

    internal static AssignmentDetailDto ToDetailDto(this Assignment assignment) => new(
        assignment.Id,
        assignment.Name.Value,
        [.. assignment.AssignmentItems.Select(i => i.ToDto())]
    );

    internal static AssignmentItemDto ToDto(this AssignmentItem item) => new(
        item.Id,
        item.Name.Value,
        item.ItemType
    );
}
