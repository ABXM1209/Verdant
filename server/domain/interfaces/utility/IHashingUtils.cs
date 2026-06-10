namespace domain.interfaces.utility;

public interface IHashingUtils
{
    void CreatePasswordHash(string password, out byte[] passwordHash);
    bool VerifyPasswordHash(string password, byte[] passwordHash);
    string GenerateRefreshToken();
}