using Domain.DTOs.ClientDTOs;
using Domain.Entities;
using Infrastructore.Responses;

namespace Infrastructore.Interfaces;

public interface IClientService
{
    public Task<Response<string>> CreateClient(AddClientDto client);
    public Task<Response<string>> UpdateClient(int id,UpdateClientDto client);
    public Task<Response<string>> DeleteClient(int id);
    public Task<Response<List<GetClientsDto>>> GetAllClients();
    public Task<Response<Client>> GetClientById(int id);
}
