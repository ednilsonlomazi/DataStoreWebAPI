namespace DataStoreWebAPI.Services
{
    // Interface para primeira populacao das roles
    public interface ISeedUserRoleInitial
    {
        Task SeedRoleAsync();
        Task SeedUserAsync();
    }
}