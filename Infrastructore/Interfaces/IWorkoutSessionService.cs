using Domain.DTOs.WorkoutSessionDTOs;
using Domain.Entities;
using Domain.Enums;
using Infrastructore.Responses;

namespace Infrastructore.Interfaces;

public interface IWorkoutSessionService
{
    public Task<Response<string>> CreateWorkoutSession(AddWorkoutSessionDto workoutSession);
    public Task<Response<string>> UpdateStatus(int id,SessionStatus status);
    public Task<Response<string>> DeleteWorkoutSession(int id);
    public Task<Response<List<GetWorkoutSessionsDto>>> GetAllWorkoutSessions();
}
