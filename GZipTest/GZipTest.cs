using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTools.GZipTest
{
    // Test fromthe following URL:
    // https://www.pcreview.co.uk/threads/gzipstream-giving-message-the-magic-number-in-gzip-header-is-notcorrect.3767313/
    class GZipTest
    {
        // compressor
        public static byte[] Compress(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (GZipStream gs = new GZipStream(ms, CompressionMode.Compress, true))
                {
                    gs.Write(bytes, 0, bytes.Length);
                }
                ms.Position = 0L;
                return ToByteArray(ms);
            }
        }

        // decompressor
        public static byte[] Decompress(byte[] bytes)
        {
            byte[] result;
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(bytes, 0, bytes.Length);

                using (GZipStream gs = new GZipStream(ms, CompressionMode.Decompress, true))
                {
                    ms.Position = 0L;
                    result = ToByteArray(gs);
                }
            }
            return result;
        }


        // streaming to byte array
        private static byte[] ToByteArray(Stream stream)
        {
            int count = 0;
            List<byte> result = new List<byte>();
            try
            {
                byte[] buffer = new byte[0x20000];
                int bytes = 0;
                while ((bytes = stream.Read(buffer, 0, 0x20000)) > 0)
                {
                    count += bytes;
                    for (int i = 0; i < bytes; i++)
                    {
                        result.AddRange(buffer);
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteErrorSync(ex);
                return null;
            }

            //LogHelper.Write(string.Format (CultureInfo.InvariantCulture, "streaming data: {0} bytes", new object [] { count }));
            return result.ToArray();
        }

        private void test()
	    {
		    // i used additional encoding to base64, you probably not ;)
            StringBuilder sb = new StringBuilder();
            string data = "";

            // compress in strint order
            string obj = Convert.ToBase64String(Compress(Encoding.UTF8.GetBytes(sb.ToString())));

            // decompress in reverse order
            string text = Encoding.UTF8.GetString(Decompress(Convert.FromBase64String(data))); 
        }
    }
}
