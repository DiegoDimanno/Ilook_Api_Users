using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCore.Repository;
using EFCore.Dominio;

namespace Ilook_Api_Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IEFCoreRepository _repo;

        public UsersController(IEFCoreRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _repo.GetAllUsers();
                return Ok(users);

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        //// PUT/Api/Users/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Users model)
        {
            try
            {
                var user = await _repo.GetUserById(id);
                if (user != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangeAsync())
                        return Ok("Atualizado com sucesso");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Não Foi possível atualizar!");
        }

        // DELETE/Api/Users
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _repo.GetUserById(id);
                if (user != null)
                {
                    _repo.Delete(user);

                    if (await _repo.SaveChangeAsync())
                        return Ok("Usuario Excluído");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Falha ao excluir!");
        }

        // POST/Api/Users
        [HttpPost()]
        public async Task<ActionResult> Post(Users model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangeAsync())
                {
                    return Ok("Salvo com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não salvou");
        }

    }
}
