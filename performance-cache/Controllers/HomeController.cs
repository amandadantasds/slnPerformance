using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Threading.Tasks;

namespace performance_cache.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using var connection = new MySqlConnection("Server=localhost;database=fiap;User=root;Password=123");
            await connection.OpenAsync();

            string sql = "SELECT id, name, email FROM users; ";
            var users = await connection.QueryAsync<Model.Users>(sql);

            return Ok(users);
        }
    }
}
