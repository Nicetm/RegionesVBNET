public interface ITokenService
{
    string GenerateToken(int regionId);
    bool ValidateToken(string token, out int regionId);
}
