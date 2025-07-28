/*
 * Azure Integration Controller - Cloud Storage Management
 * 
 * This controller provides endpoints for integrating with Azure cloud storage services,
 * specifically handling file operations and secure access token generation.
 * It demonstrates enterprise-level cloud integration patterns for the TTRPG platform.
 * 
 * Key Features:
 * - Secure file access through SAS (Shared Access Signature) tokens
 * - Temporary URI generation for client-side file access
 * - Error handling for missing files and access violations
 * 
 * Security Model:
 * - Uses SAS tokens to provide time-limited, permission-scoped access to Azure storage
 * - Prevents direct storage account key exposure to client applications
 * - Enables secure file sharing without compromising storage security
 * 
 * Use Cases:
 * - Character portraits and images
 * - Game assets and resources
 * - User-generated content storage
 * - Temporary file sharing between users
 */

using Microsoft.AspNetCore.Mvc;

namespace JuggleHiveWebapp.Server.Controllers
{
    /// <summary>
    /// API Controller for Azure cloud storage integration
    /// Provides secure access to cloud-stored files through SAS tokens
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AzureController : ControllerBase
    {
        private readonly IAzureFileService _azureFileService;

        /// <summary>
        /// Constructor with dependency injection for Azure file service
        /// </summary>
        /// <param name="azureFileService">Service for handling Azure storage operations</param>
        public AzureController(IAzureFileService azureFileService)
        {
            _azureFileService = azureFileService;
        }

        /// <summary>
        /// Generates a temporary URI with SAS token for secure file access
        /// GET: api/azure/TempFileURI?fileName={fileName}
        /// 
        /// This endpoint creates a time-limited, secure URL that allows clients to access
        /// files stored in Azure without exposing storage account credentials.
        /// </summary>
        /// <param name="fileName">Name of the file in Azure storage</param>
        /// <returns>
        /// 200 OK with SAS URI string if file exists
        /// 404 Not Found if file doesn't exist in storage
        /// </returns>
        [HttpGet("TempFileURI")]
        public async Task<IActionResult> TempFileURI(string fileName)
        {
            try
            {
                // Generate SAS URI with time-limited access permissions
                // This provides secure, temporary access to the requested file
                Uri uriWithSas = await _azureFileService.GenerateSasUriAsync(fileName);
                
                // Return the SAS URI as a string for client consumption
                return Ok(uriWithSas.ToString());
            }
            catch (FileNotFoundException)
            {
                // Handle case where requested file doesn't exist in Azure storage
                // Return appropriate HTTP status code for client error handling
                return NotFound("File does not exist.");
            }
        }
    }
}