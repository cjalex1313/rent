using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Rent.FileManager
{
    public interface IFileManager
    {
        void UploadFile(string key, Stream data);
        string GetFileCDN(string key);
        Task DeleteFile(string key);
    }
}
