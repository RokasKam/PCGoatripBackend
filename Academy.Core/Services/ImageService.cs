using Academy.Core.Interfaces;
using Firebase.Auth;
using Firebase.Storage;

namespace Academy.Core.Services;

public class ImageService : IImageService
{
    private string _firebaseStorageApiKey = "AIzaSyDA_zFqAgTsB46UI5j2POsA8y6Rzd0__qw";
    private string _firebaseStorageAuthEmail = "admin@goatrip.com";
    private string _firebaseStorageAuthPassword = "Pa$$w0rd";
    private string _firebaseStorageBucket = "goatrip-a93b5.appspot.com";
    
    public Stream ConvertBase64ToStream(string imageFromRequest)
    {
        byte[] imageStringToBase64 = Convert.FromBase64String(imageFromRequest);
        StreamContent streamContent = new(new MemoryStream(imageStringToBase64));
        return streamContent.ReadAsStream();
    }
    
    public async Task<string> UploadImage(Stream stream, string imageName)
    {
        FirebaseAuthProvider firebaseConfiguration = new(new FirebaseConfig(_firebaseStorageApiKey));

        FirebaseAuthLink authConfiguration = await firebaseConfiguration
            .SignInWithEmailAndPasswordAsync(_firebaseStorageAuthEmail, _firebaseStorageAuthPassword);

        CancellationTokenSource cancellationToken = new CancellationTokenSource();
        
        FirebaseStorageTask storageManager = new FirebaseStorage(
                _firebaseStorageBucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(authConfiguration.FirebaseToken),
                    ThrowOnCancel = true
                })
            .Child(imageName)
            .PutAsync(stream, cancellationToken.Token);
        
        string imageFromFirebaseStorage;
        try
        {
            imageFromFirebaseStorage = await storageManager;
        }
        catch (Exception exc)
        {
            throw new Exception(exc.Message);
        }
        return imageFromFirebaseStorage;
    }
}