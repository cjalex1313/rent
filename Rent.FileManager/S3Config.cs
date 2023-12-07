namespace Rent.FileManager
{
    internal class S3Config
    {
        public string BucketName { get; set; } = "";
        public string AccessKey { get; set; } = "";
        public string SecretKey { get; set; } = "";
        public string Region { get; set; } = "";
        public string ServiceUrl { get; set; } = "";
        public string Prefix { get; set; } = "";
    }
}
