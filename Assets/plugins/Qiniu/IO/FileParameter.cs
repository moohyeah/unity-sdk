using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qiniu.IO
{
    class PutParameter
    {
        protected string mimeType;

        public string MimeType
        {
            get { return mimeType; }
            set { mimeType = value; }
        }        
        public PutParameter(string mimeType)
        {
            this.mimeType = mimeType;
        }
        public virtual long CopyTo(Stream body)
        {
            return 0;
        }
    }
    class StreamParameter:PutParameter
    {
        private System.IO.StreamReader reader;

        public System.IO.StreamReader Reader
        {
            get { return reader; }
            set { reader = value; }
        }
        public StreamParameter(StreamReader reader, string mimeType):base(mimeType)
        {
           this.reader = reader;
        }
        public override long CopyTo(Stream body)
        {
            return 0;
        }
    }
    class FileParameter : PutParameter
    {
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        
        public FileParameter(string fname, string mimeType):base(mimeType)
        {
            this.fileName = fname;
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[32768];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }

        public override long CopyTo(Stream body)
        {
            using (FileStream fs = File.OpenRead(this.fileName))
            {
                //fs.CopyTo(body);
                CopyStream(fs, body);
                return fs.Length;
            }           
        }
    }
}
