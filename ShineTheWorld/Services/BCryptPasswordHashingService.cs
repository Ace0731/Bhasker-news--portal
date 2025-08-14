using BCrypt.Net;

namespace ShineTheWorld.Services;

/// <summary>
/// BCrypt implementation of password hashing service
/// </summary>
public class BCryptPasswordHashingService : IPasswordHashingService
{
    private const int WorkFactor = 12; // Recommended work factor for BCrypt

    /// <summary>
    /// Hashes a password using BCrypt with automatic salt generation
    /// </summary>
    /// <param name="password">The plain text password to hash</param>
    /// <returns>The BCrypt hashed password with salt</returns>
    /// <exception cref="ArgumentException">Thrown when password is null or empty</exception>
    public string HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password cannot be null or empty", nameof(password));
        }

        return BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
    }

    /// <summary>
    /// Verifies a password against its BCrypt hash
    /// </summary>
    /// <param name="password">The plain text password to verify</param>
    /// <param name="hash">The stored BCrypt hash to verify against</param>
    /// <returns>True if the password matches the hash, false otherwise</returns>
    /// <exception cref="ArgumentException">Thrown when password or hash is null or empty</exception>
    public bool VerifyPassword(string password, string hash)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password cannot be null or empty", nameof(password));
        }

        if (string.IsNullOrEmpty(hash))
        {
            throw new ArgumentException("Hash cannot be null or empty", nameof(hash));
        }

        try
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
        catch (SaltParseException)
        {
            // Invalid hash format
            return false;
        }
    }
}