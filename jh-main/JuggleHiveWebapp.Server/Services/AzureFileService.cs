/*
 * Azure File Service - Cloud Storage Integration Service
 * 
 * This service provides secure integration with Azure File Storage, implementing
 * enterprise-level cloud storage patterns for the TTRPG platform. It handles
 * authentication, authorization, and secure file access through SAS tokens.
 * 
 * Key Features:
 * - Environment-based configuration for secure credential management
 * - SAS (Shared Access Signature) token generation for time-limited file access
 * - File existence validation before access token generation
 * - Secure credential management without exposing storage keys to clients
 * 
 * Security Model:
 * - Uses Shared Key Credential for server-side authentication
 * - Generates time-limited SAS tokens (30-minute expiration)
 * - Provides granular permissions (Read/Write) for file access
 * - Validates file existence before granting access
 * 
 * Architecture:
 * - Implements IAzureFileService interface for loose coupling
 * - Uses Azure SDK for .NET for reliable cloud integration
 * - Environment variable configuration for deployment flexibility
 */

using Azure.Storage.Files.Shares;
using Azure.Storage;
using Azure.Storage.Sas;

/// <summary>
/// Service implementation for Azure File Storage operations
/// Provides secure file access through SAS token generation
/// </summary>
public class AzureFileService : IAzureFileService
{
    private readonly string _accountName;
    private readonly string _accountKey;

    /// <summary>
    /// Constructor that initializes Azure storage credentials from environment variables
    /// This pattern keeps sensitive credentials out of code and configuration files
    /// </summary>
    /// <exception cref="ArgumentNullException">Thrown when required environment variables are missing</exception>
    public AzureFileService()
    {
        // Load Azure storage account credentials from environment variables
        // This enables secure deployment without hardcoding sensitive information
        _accountName = Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT_NAME") 
            ?? throw new ArgumentNullException("AZURE_STORAGE_ACCOUNT_NAME");
        _accountKey = Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT_KEY") 
            ?? throw new ArgumentNullException("AZURE_STORAGE_ACCOUNT_KEY");
    }

    /// <summary>
    /// Generates a SAS URI for secure, time-limited access to a specific file
    /// This allows clients to access files directly from Azure without server proxy
    /// </summary>
    /// <param name="fileName">Name of the file in Azure storage (with or without leading slash)</param>
    /// <returns>URI with SAS token for direct file access</returns>
    /// <exception cref="FileNotFoundException">Thrown when the requested file doesn't exist</exception>
    public async Task<Uri> GenerateSasUriAsync(string fileName)
    {
        // Normalize filename by removing leading slash if present
        // This ensures consistent path handling regardless of input format
        if (fileName.StartsWith("/"))
        {
            fileName = fileName.Substring(1);
        }

        // Create shared key credential for Azure authentication
        // This uses the storage account key for server-side authentication
        StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(_accountName, _accountKey);

        // Construct the base URI for the file in the 'public' share
        // Azure File Storage uses hierarchical structure: account/share/directory/file
        Uri baseUri = new Uri("https://" + _accountName + ".file.core.windows.net/public/" + fileName);
        ShareFileClient fileClient = new ShareFileClient(baseUri, sharedKeyCredential);

        // Verify file exists before generating access token
        // This prevents creating SAS tokens for non-existent files
        if (!await fileClient.ExistsAsync())
        {
            throw new FileNotFoundException("File does not exist.");
        }

        // Configure SAS token parameters for secure, time-limited access
        ShareUriBuilder shareUriBuilder = new ShareUriBuilder(baseUri);
        
        // Grant both read and write permissions to the file
        // Consider restricting to read-only for enhanced security if write access isn't needed
        ShareFileSasPermissions permissions = ShareFileSasPermissions.Read | ShareFileSasPermissions.Write;
        
        // Set token expiration to 30 minutes from now
        // This balances usability with security by limiting exposure time
        DateTimeOffset expiresOn = DateTimeOffset.UtcNow.AddMinutes(30);

        // Build the SAS token with specified permissions and expiration
        ShareSasBuilder sasBuilder = new ShareSasBuilder
        {
            ShareName = shareUriBuilder.ShareName,
            FilePath = shareUriBuilder.DirectoryOrFilePath,
            Resource = "f", // 'f' indicates this is a file resource (not container)
            ExpiresOn = expiresOn
        };

        // Apply the permissions to the SAS builder
        sasBuilder.SetPermissions(permissions);
        
        // Generate the SAS query parameters using the shared key credential
        shareUriBuilder.Sas = sasBuilder.ToSasQueryParameters(sharedKeyCredential);

        // Return the complete URI with embedded SAS token
        return shareUriBuilder.ToUri();
    }
}
