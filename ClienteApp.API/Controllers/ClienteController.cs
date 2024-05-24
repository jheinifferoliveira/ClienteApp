using ClienteApp.API.DTOs.Request;
using ClienteApp.API.DTOs.Response;
using ClientesApp.Domain.Entities;
using ClientesApp.Domain.Interfaces.Repositories;
using ClientesApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Eventing.Reader;

namespace ClienteApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteDomainService _clienteDomainService;

        public ClienteController(IClienteRepository clienteRepository, IClienteDomainService clienteDomainService)
        {
            _clienteRepository = clienteRepository;
            _clienteDomainService = clienteDomainService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarClienteRequestDto), 201)]
        public IActionResult Post(CriarClienteRequestDto dto)
        {
            try
            {
                var cliente = new Cliente()
                {
                    Id = Guid.NewGuid(),
                    DataHoraCadastro = DateTime.Now,
                    Nome = dto.Nome,
                    Email = dto.Email,
                    Cpf = dto.Cpf,
                };

                _clienteDomainService.CriarCliente(cliente);

                var response = new CriarClienteResponseDto()
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Cpf = cliente.Cpf,
                    DataHoraCadastro = cliente.DataHoraCadastro
                };

                return StatusCode(201, response);
            }
            catch (ApplicationException e) {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(501, new { e.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(EditarClienteResponseDto), 200)]
        public IActionResult Put(EditarClienteRequestDto dto)
        {
            try
            {
                var cliente = _clienteRepository.GetById(dto.Id);

                if (cliente != null)
                {
                    cliente.Nome = dto.Nome;
                    cliente.Email = dto.Email;
                    cliente.Cpf = dto.Cpf;
                }

                _clienteRepository.Update(cliente);

                var response = new EditarClienteResponseDto
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Cpf = cliente.Cpf,
                    DataHoraUltimaAtualizacao = DateTime.Now
                };

                return StatusCode(200, response);
            }

            catch (Exception e)
            {
                return StatusCode(501, new { e.Message });
            }


        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ExcluirClienteResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var cliente = _clienteRepository.GetById(id);

                if (cliente != null)
                {
                    _clienteRepository.Delete(cliente);

                    var response = new ExcluirClienteResponseDto()
                    {
                        Id = id,
                        DataHoraExclusao = DateTime.Now
                    };

                    return StatusCode(200, response);
                }

                else
                {
                    return StatusCode(400, new { message = "O id do cliente é inválido" });
                }

            }
            catch (Exception e)
            {
                return StatusCode(501, new { e.Message });
            }

        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ConsultarClienteResponseDto>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var response = new List<ConsultarClienteResponseDto>().ToList();
                foreach (var item in _clienteRepository.GetAll())
                {
                    response.Add(new ConsultarClienteResponseDto
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Email=item.Email,
                        Cpf=item.Cpf,
                        DataHoraCadastro=item.DataHoraCadastro
                    });
                }

                return StatusCode(200, response);
            }
            catch(Exception e)
            {
                return StatusCode(501, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConsultarClienteResponseDto),200)]
        public IActionResult GetById(Guid id)
        {
            try
            {

                var cliente = _clienteRepository.GetById(id);
                if(cliente != null)
                {
                    var response = new ConsultarClienteResponseDto(){

                        Id = cliente.Id,
                        Nome=cliente.Nome,
                        Cpf=cliente.Cpf,
                        Email=cliente.Email,
                        DataHoraCadastro=cliente.DataHoraCadastro

                    };



                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(400, new { message = "O id do cliente é inválido" });
                }
            }
            catch(Exception e)
            {
                return StatusCode(501, new { e.Message });
            }
            
        }



    }
}
