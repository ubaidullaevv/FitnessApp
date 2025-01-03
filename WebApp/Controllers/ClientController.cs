using Domain.DTOs.ClientDTOs;
using Domain.Entities;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ClientController(IClientService service):ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> Create(AddClientDto client) => await service.CreateClient(client);
    public async Task<Response<string>> Update(int id,UpdateClientDto client) => await service.UpdateClient(id,client);
    public async Task<Response<string>> Delete(int id) => await service.DeleteClient(id);
    public async Task<Response<Client>> GetbyId(int id) => await service.GetClientById(id);
    public async Task<Response<List<GetClientsDto>>> GetAll() => await service.GetAllClients();
}
