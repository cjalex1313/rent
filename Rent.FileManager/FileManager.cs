using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Rent.FileManager
{
    internal class FileManager : IFileManager
    {
        private readonly S3Config _s3Config;

        public FileManager(S3Config s3Config)
        {
            _s3Config = s3Config;
        }

        public string GetFileCDN(string key)
        {
            var client = GetAWSClient();
            var request = new GetPreSignedUrlRequest()
            {
                BucketName = _s3Config.BucketName,
                Key = _s3Config.Prefix + key,
                Expires = DateTime.Now.AddDays(1)
            };
            var url = client.GetPreSignedURL(request);
            return url;
        }

        public void UploadFile(string key, Stream data)
        {
            var client = GetAWSClient();
            var transferUtility = new TransferUtility(client);
            var uploadRequest = new TransferUtilityUploadRequest()
            {
                InputStream = data,
                Key = _s3Config.Prefix + key,
                BucketName = _s3Config.BucketName,
                CannedACL = S3CannedACL.PublicReadWrite
            };
            transferUtility.Upload(uploadRequest);
        }

        private AmazonS3Client GetAWSClient()
        {
            var config = new AmazonS3Config()
            {
                ForcePathStyle = false,
                ServiceURL = _s3Config.ServiceUrl,
                RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(_s3Config.Region)
            };
            config.ServiceURL = _s3Config.ServiceUrl;
            var credentials = new BasicAWSCredentials(_s3Config.AccessKey, _s3Config.SecretKey);
            var client = new AmazonS3Client(credentials, config);
            return client;
        }
    }
}
