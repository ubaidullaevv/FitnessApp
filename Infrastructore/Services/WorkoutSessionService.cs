using System.Net;
using Domain.DTOs.WorkoutSessionDTOs;
using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using Infrastructore.Data;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Services;

public class WorkoutSessionService(DataContext context) : IWorkoutSessionService
{
    public async Task<Response<string>> CreateWorkoutSession(AddWorkoutSessionDto workoutSession)
    {
        var WorkoutSessionDto=new WorkoutSession(){
            ClientId = workoutSession.ClientId,
            TrainerId = workoutSession.TrainerId,
            WorkoutID = workoutSession.WorkoutID,
            Comment= workoutSession.Comment,
            CreatedAt= workoutSession.CreatedAt,
            EndTime= workoutSession.EndTime,
            CurrentParticipants= workoutSession.CurrentParticipants,
            MaxCapacity= workoutSession.MaxCapacity,
            SessionDate= workoutSession.SessionDate,
            SessionStatus= workoutSession.SessionStatus,
            StartTime= workoutSession.StartTime
        };
        await context.WorkoutSessions.AddAsync(WorkoutSessionDto);
        var res= await context.SaveChangesAsync();
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError,"WorkoutSession not created!")
        : new Response<string>("WorkoutSession created successfully!");
    }

    public async Task<Response<string>> DeleteWorkoutSession(int id)
    {
       var exist=await context.WorkoutSessions.FirstOrDefaultAsync(x=>x.Id==id);
       if(exist==null) return new Response<string>(HttpStatusCode.NotFound,"WorkoutSession not found!");
        context.WorkoutSessions.Remove(exist);
        var res=await context.SaveChangesAsync();
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError,"WorkoutSession not deleted!")
        : new Response<string>("WorkoutSession deleted successfully!");
    }

    public async Task<Response<List<GetWorkoutSessionsDto>>> GetAllWorkoutSessions()
    {
        var WorkoutSession=await context.WorkoutSessions.ToListAsync();
        var res=WorkoutSession.Select(w=> new GetWorkoutSessionsDto(){
                 ClientId = w.ClientId,
                 TrainerId=w.TrainerId,
                 WorkoutId=w.WorkoutID,
                Comment = w.Comment,
                CreatedAt = w.CreatedAt,
                CurrentParticipants = w.CurrentParticipants,
                EndTime = w.EndTime,
                Id = w.Id,
                MaxCapacity = w.MaxCapacity,
                SessionDate = w.SessionDate,
                SessionStatus = w.SessionStatus,
                StartTime = w.StartTime,
            }).ToList();
        return new Response<List<GetWorkoutSessionsDto>>(res);
    }


    public async Task<Response<string>> UpdateStatus(int id,SessionStatus status)
    {
      var exist=await context.WorkoutSessions.FirstOrDefaultAsync(x=>x.Id==id);
       if(exist==null) return new Response<string>(HttpStatusCode.NotFound,"WorkoutSession not found!");
       exist.SessionStatus=status;
       var res=await context.SaveChangesAsync();
       return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError,"WorkoutSession not updated!")
        : new Response<string>("WorkoutSession updated successfully!");
    }


}
