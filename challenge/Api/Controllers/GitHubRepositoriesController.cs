using challenge.Models;
using challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubRepositoriesController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;

        public GitHubRepositoriesController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpGet("oldest")]
        public async Task<ActionResult<IEnumerable<GitHubRepo>>> GetOldestRepositories()
        {
            var repos = await _gitHubService.GetOldestRepositories();
            return Ok(repos);
        }
    }
}
