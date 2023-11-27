using Rent.FileManager;

namespace Rent.BS.File
{
    internal class FileService : IFileService
    {
        private readonly IFileManager _fileManager;

        public FileService(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public string GetCDN(string key)
        {
            var cdn = _fileManager.GetFileCDN(key);
            return cdn;
        }

        public void UploadTestFile(string fileName, Stream data)
        {
            _fileManager.UploadFile(fileName, data);
        }
    }
}
