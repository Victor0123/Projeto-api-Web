using Amazon.S3;
using Amazon.S3.Transfer;

namespace Projeto_api_Web.Services
{
    public class AmazonS3Service
    {
        private readonly IAmazonS3 _s3client;

        public AmazonS3Service() 
        { 
            _s3client = new AmazonS3Client();
        }
        
        public async Task<bool> UploadFileAsync(string bucket, string key, IFormFile file)
        {
            using var Stream = new MemoryStream();
            file.CopyTo(Stream);

            var fileTransferUtility = new TransferUtility(_s3client);

            //var putObjectRequest = new PutObjectRequest
            //{
            //    BucketName = bucket,
            //    Key = key,
            //    ContentType = file.ContentType,
            //    InputStream = Stream
            //};

            //var upload = await _s3client.PutObjectAsync(putObjectRequest);


            await fileTransferUtility.UploadAsync(new TransferUtilityUploadRequest
            {
                BucketName = bucket,
                Key = key,
                ContentType = file.ContentType,
                InputStream = Stream,
            });

            return true;
        }
    }

    
}
