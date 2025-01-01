using System.Net;
using Domain.DTOs.ClientDTOs;
using Domain.DTOs.WorkoutSessionDTOs;
using Domain.Entities;
using Infrastructore.Data;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Services;

public class ClientService(DataContext context) : IClientService
{
    public async Task<Response<string>> CreateClient(AddClientDto client)
    {
        var ClientDto=new Client(){
            DateOfBirth = client.DateOfBirth,
            FirstName = client.FirstName,
            LastName = client.LastName,
            PhoneNumber= client.PhoneNumber,
            Email= client.Email,
            MembershipStatus= client.MembershipStatus
        };
        await context.Clients.AddAsync(ClientDto);
        var res= await context.SaveChangesAsync();
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Client not created!")
        : new Response<string>("Client created successfully!");
    }

    public async Task<Response<string>> DeleteClient(int id)
    {
       var exist=await context.Clients.FirstOrDefaultAsync(x=>x.Id==id);
       if(exist==null) return new Response<string>(HttpStatusCode.NotFound,"Client not found!");
        context.Clients.Remove(exist);
        var res=await context.SaveChangesAsync();
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Client not deleted!")
        : new Response<string>("Client deleted successfully!");
    }

    public async Task<Response<List<GetClientsDto>>> GetAllClients()
    {
        var Client=await context.Clients.Include(w=>w.WorkoutSessions).ToListAsync();
        var res=Client.Select(x=> new GetClientsDto(){
            DateOfBirth = x.DateOfBirth,
            FirstName = x.FirstName,
            Id = x.Id,
            LastName = x.LastName,
            PhoneNumber = x.PhoneNumber,
            Email = x.Email,
             MembershipStatus = x.MembershipStatus,
            WorkoutSessions=x.WorkoutSessions.Select(w=>new GetWorkoutSessionsDto(){
                ClientId = w.ClientId,
                Comment = w.Comment,
                CreatedAt = w.CreatedAt,
                CurrentParticipants = w.CurrentParticipants,
                EndTime = w.EndTime,
                Id = w.Id,
                MaxCapacity = w.MaxCapacity,
                SessionDate = w.SessionDate,
                SessionStatus = w.SessionStatus,
                StartTime = w.StartTime,
                WorkoutId = w.WorkoutID
            }).ToList()
        }).ToList();
        return new Response<List<GetClientsDto>>(res);
    }

    public async Task<Response<Client>> GetClientById(int id)
    {
       var exist=await context.Clients.FirstOrDefaultAsync(x=>x.Id==id);
       if(exist==null) return new Response<Client>(HttpStatusCode.NotFound,"Client not found!");
       return new Response<Client>(exist) ;       
    }

    public async Task<Response<string>> UpdateClient(int id,UpdateClientDto Client)
    {
      var exist=await context.Clients.FirstOrDefaultAsync(x=>x.Id==id);
       if(exist==null) return new Response<string>(HttpStatusCode.NotFound,"Client not found!");
       exist.DateOfBirth = Client.DateOfBirth;
       exist.FirstName = Client.FirstName;;   
       exist.LastName = Client.LastName;
       exist.PhoneNumber=Client.PhoneNumber;
       exist.Email = Client.Email;
       exist.MembershipStatus = Client.MembershipStatus;
       var res=await context.SaveChangesAsync();
       return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError,"Client not updated!")
        : new Response<string>("Client updated successfully!");
    }


}
