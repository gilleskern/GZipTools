using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace GZipTools
{
    public class Compress
    {
        private readonly IScintillaGateway scintilla;
        private GZipTest test;

        public Compress(IScintillaGateway scintilla)
        {
            this.scintilla = scintilla;
            test = new GZipTest();
        }

        public void GZip()
        {
            // Read current document.
            int length = scintilla.GetTextLength();
            string text = scintilla.GetText(length);

            // Compress text
            //string compressedText = CompressString(text);
            string compressedText = Convert.ToBase64String(test.Compress(Encoding.UTF8.GetBytes(text)));

            // Delete all text in the document.
            scintilla.ClearAll();

            // Display compressed text
            scintilla.SetText(compressedText);
        }

        public void GUnzip()
        {
            // Read current document.
            int length = scintilla.GetTextLength();
            string compressedText = scintilla.GetText(length);

            // Uncompress text
            //string text = DecompressString(compressedText);
            string text = Encoding.UTF8.GetString(test.Decompress(Convert.FromBase64String(compressedText)));

            // Delete all text in the document.
            scintilla.ClearAll();

            // Display compressed text
            scintilla.SetText(text);
        }

        /// <summary>
        /// Compresses the string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        private string CompressString(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
            return Convert.ToBase64String(gZipBuffer);
        }

        /// <summary>
        /// Decompresses the string.
        /// </summary>
        /// <param name="compressedText">The compressed text.</param>
        /// <returns></returns>
        private string DecompressString(string compressedText)
        {
            //using GZipStream decoder = new GZipStream(gzStream, CompressionMode.Decompress, true);
            //MemoryStream decodedStream = new MemoryStream();
            //decoder.CopyTo(decodedStream);
            //return decodedStream;


            try
            {
                //byte[] gZipBuffer = Convert.FromBase64String(compressedText);
                byte[] gZipBuffer = Encoding.UTF8.GetBytes(compressedText);
                using (var memoryStream = new MemoryStream())
                {
                    int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                    memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                    var buffer = new byte[dataLength];

                    memoryStream.Position = 0;
                    using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        gZipStream.Read(buffer, 0, buffer.Length);
                    }

                    return Encoding.UTF8.GetString(buffer);
                }
            }
            catch (Exception ex)
            {
                string message = ex.ToString();

                return message;
            }
        }

        public static string UnZip(string value)
        {
            try
            {
                //Transform string into byte[]
                byte[] byteArray = new byte[value.Length];
                int indexBA = 0;
                foreach (char item in value.ToCharArray())
                {
                    byteArray[indexBA++] = (byte)item;
                }

                //Prepare for decompress
                System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArray);
                System.IO.Compression.GZipStream sr = new System.IO.Compression.GZipStream(ms,
                    System.IO.Compression.CompressionMode.Decompress);

                //Reset variable to collect uncompressed result
                byteArray = new byte[byteArray.Length];

                //Decompress
                int rByte = sr.Read(byteArray, 0, byteArray.Length);

                //Transform byte[] unzip data to string
                System.Text.StringBuilder sB = new System.Text.StringBuilder(rByte);
                //Read the number of bytes GZipStream red and do not a for each bytes in
                //resultByteArray;
                for (int i = 0; i < rByte; i++)
                {
                    sB.Append((char)byteArray[i]);
                }
                sr.Close();
                ms.Close();
                sr.Dispose();
                ms.Dispose();
                return sB.ToString();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();

                return message;
            }
            finally
            { 
            
            }
        }
    }
}
