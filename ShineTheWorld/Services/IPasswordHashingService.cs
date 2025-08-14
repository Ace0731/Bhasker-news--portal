namespace ShineTheWorld.Services;

/// <summary>
/// Interface for secure password hashing operations
/// </summary>
public interface IPasswordHashingService
{
    /// <summary>
    /// Hashes a password using a secure algorithm with salt generation
    /// </summary>
    /// <param name="password">The plain text password to hash</param>
    /// <returns>The hashed password with salt</returns>
    string HashPassword(string password);

    /// <summary>
    /// Verifies a password against its hash
    /// </summary>
    /// <param name="password">The plain text password to verify</param>
    /// <param name="hash">The stored hash to verify against</param>
    /// <returns>True if the password matches the hash, false otherwise</returns>
    bool VerifyPassword(string password, string hash);
}