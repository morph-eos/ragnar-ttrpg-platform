using Microsoft.AspNetCore.Mvc;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureController : ControllerBase
    {
        private readonly IAzureFileService _azureFileService;

        public AzureController(IAzureFileService azureFileService)
        {
            _azureFileService = azureFileService;
        }

        [HttpGet("TempFileURI")]
        public async Task<IActionResult> TempFileURI(string fileName)
        {
            try
            {
                Uri uriWithSas = await _azureFileService.GenerateSasUriAsync(fileName);
                return Ok(uriWithSas.ToString());
            }
            catch (FileNotFoundException)
            {
                return NotFound("File does not exist.");
            }
        }
    }
}