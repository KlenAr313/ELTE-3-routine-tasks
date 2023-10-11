using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ELTE.DocuStat.Persistence
{
    public class TextFileManager : IFileManager
    {
        private readonly string _filePath;
        public class FileManagerException : IOException {
            public FileManagerException(string message, Exception inner) : base(message, inner) { }
        };

        public TextFileManager(string filePath)
        {
            this._filePath = filePath;
        }

        public string Load()
        {
            try
            {
                return File.ReadAllText(_filePath);
            }
            catch (Exception ex)
            {
                throw new FileManagerException(ex.Message, ex);
            }
        }
    }
}
