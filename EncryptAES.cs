using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GZipTools
{
    public class EncryptAES
    {
        private readonly IScintillaGateway scintilla;
        private byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private int BlockSize = 128;

        public EncryptAES(IScintillaGateway scintilla)
        {
            this.scintilla = scintilla;
        }

        public void Encrypt(string key)
        {
            try
            {
                // Start undo method
                scintilla.BeginUndoAction();

                // Read current document.
                int length = scintilla.GetTextLength();
                string text = scintilla.GetText(length + 1);

                // Uncompress text
                string encryptedText = EncryptString(text, key);

                // Delete all text in the document.
                scintilla.ClearAll();

                // Display compressed text
                scintilla.SetText(encryptedText);
            }
            catch
            {
                string error = "Error while encrypting message.";

                scintilla.SetText(error);
            }
            finally
            {
                scintilla.EndUndoAction();
            }
        }

        public void Decrypt(string key)
        {
            try
            {
                // Start undo method
                scintilla.BeginUndoAction();

                // Read current document.
                int length = scintilla.GetTextLength();
                string encryptedText = scintilla.GetText(length + 1);

                // Uncompress text
                string text = DecryptString(encryptedText, key);

                // Delete all text in the document.
                scintilla.ClearAll();

                // Display compressed text
                scintilla.SetText(text);
            }
            catch
            {
                string error = "Error while decrypting message.";

                scintilla.SetText(error);
            }
            finally
            {
                scintilla.EndUndoAction();
            }
        }

        // Reference: https://www.codeproject.com/Articles/1278566/Simple-AES-Encryption-using-Csharp
        private string EncryptString(string text, string key)
        {
            if (text == "") return string.Empty;
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            //Encrypt
            SymmetricAlgorithm crypt = Aes.Create();
            crypt.BlockSize = BlockSize;
            crypt.Key = Convert.FromBase64String(key);
            crypt.IV = IV;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytes, 0, bytes.Length);
                }

                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        private string DecryptString(string text, string key)
        {
            if (text == "") return string.Empty;
            //Decrypt
            byte[] bytes = Convert.FromBase64String(text);
            SymmetricAlgorithm crypt = Aes.Create();
            crypt.Key = Convert.FromBase64String(key);
            crypt.IV = IV;

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] decryptedBytes = new byte[bytes.Length];
                    cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }
    }
}
