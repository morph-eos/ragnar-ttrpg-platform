public interface IAzureFileService
{
    Task<Uri> GenerateSasUriAsync(string fileName);
}