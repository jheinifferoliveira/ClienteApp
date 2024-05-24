using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Domain.Services
{
    public class ClienteDomainService: IClienteDomainService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDomainService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void CriarCliente(Cliente cliente)
        {
          if ( _clienteRepository.GetByCpf(cliente.Cpf) != null )
            {
                throw new ApplicationException("O cpf informado já está cadastrado, tente outro. ");
            }

            _clienteRepository.Add(cliente);
        }
    }
}
