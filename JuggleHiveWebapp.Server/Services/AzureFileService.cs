using Azure.Storage.Files.Shares;
using Azure.Storage;
using Azure.Storage.Sas;

public class AzureFileService : IAzureFileService
{
    private readonly string _accountName;
    private readonly string _accountKey;

    public AzureFileService()
    {
        _accountName = Environment.GetEnvironmentVariable("AZURE_ACCOUNT_NAME") ?? throw new ArgumentNullException("AZURE_ACCOUNT_NAME");
        _accountKey = Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT_KEY") ?? throw new ArgumentNullException("AZURE_STORAGE_ACCOUNT_KEY");
    }

    public async Task<Uri> GenerateSasUriAsync(string fileName)
    {
        if (fileName.StartsWith("/"))
        {
            fileName = fileName.Substring(1);
        }

        StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(_accountName, _accountKey);

        Uri baseUri = new Uri("https://" + _accountName + ".file.core.windows.net/public/" + fileName);
        ShareFileClient fileClient = new ShareFileClient(baseUri, sharedKeyCredential);

        if (!await fileClient.ExistsAsync())
        {
            throw new FileNotFoundException("File does not exist.");
        }

        ShareUriBuilder shareUriBuilder = new ShareUriBuilder(baseUri);
        ShareFileSasPermissions permissions = ShareFileSasPermissions.Read | ShareFileSasPermissions.Write;
        DateTimeOffset expiresOn = DateTimeOffset.UtcNow.AddMinutes(30);

        ShareSasBuilder sasBuilder = new ShareSasBuilder
        {
            ShareName = shareUriBuilder.ShareName,
            FilePath = shareUriBuilder.DirectoryOrFilePath,
            Resource = "f",
            ExpiresOn = expiresOn
        };

        sasBuilder.SetPermissions(permissions);
        shareUriBuilder.Sas = sasBuilder.ToSasQueryParameters(sharedKeyCredential);

        return shareUriBuilder.ToUri();
    }
}
