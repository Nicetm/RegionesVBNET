namespace WebApp.Services
{
    public interface IHashService
    {
        string GenerateHash(string data);
        bool ValidateHash(string hash, string data);
    }
}