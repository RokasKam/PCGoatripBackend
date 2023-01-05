namespace Academy.Core.Interfaces;

public interface IImageService
{
    Stream ConvertBase64ToStream(string imageFromRequest);
    Task<string> UploadImage(Stream stream, string imageName);
}