using Domain.DTOs.WorkoutSessionDTOs;
using Domain.Entities;
using Domain.Enums;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class WorkoutSessionController(IWorkoutSessionService service):ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> Create(AddWorkoutSessionDto WorkoutSession) => await service.CreateWorkoutSession(WorkoutSession);
    public async Task<Response<string>> Update(int id,SessionStatus status) => await service.UpdateStatus(id,status);
    public async Task<Response<string>> Delete(int id) => await service.DeleteWorkoutSession(id);
    public async Task<Response<List<GetWorkoutSessionsDto>>> GetAll() => await service.GetAllWorkoutSessions();
}
