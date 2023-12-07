using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.BS.File
{
    public interface IFileService
    {
        void UploadTestFile(string fileName, Stream data);
        string GetCDN(string key);
    }
}
