namespace RecipeWebsite.Services.Interfaces;

public interface IImageService
{
    string ContentType(IFormFile file);
    string DecodeImage(byte[] data, string type);
    Task<byte[]> EncodeImageAsync(IFormFile file);
    Task<byte[]> EncodeImageAsync(string fileName);
    int Size(IFormFile file);
}