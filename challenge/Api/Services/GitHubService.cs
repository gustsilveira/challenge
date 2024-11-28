using challenge.Models;

namespace challenge.Services
{
    public interface IGitHubService
    {
        Task<List<GitHubRepo>> GetOldestRepositories(int count = 5);
    }

    public class GitHubService : IGitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.DefaultRequestHeaders.Add("User-Agent", "challenge");

        }

        public async Task<List<GitHubRepo>> GetOldestRepositories(int count = 5)
        {
            var response = await _httpClient.GetFromJsonAsync<List<GitHubRepo>>("https://api.github.com/users/takenet/repos?per_page=100");
            if (response == null)
            {
                return new List<GitHubRepo>();
            }

            return response.OrderBy(repo => repo.CreatedAt).Take(count).ToList();
        }

    }
}
