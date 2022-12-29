using Framework.Crypto;
using System.IO;
using System.Security.Cryptography;

namespace Framework.Crypto
{
    internal class Decryptor
    {
        private readonly DecryptTransformer transformer;
        private byte[] initVec;

        public Decryptor(EncryptionAlgorithm id)
        {
            transformer = new DecryptTransformer(id);
        }

        public byte[] IV
        {
            set { initVec = value; }
            get { return initVec; }
        }



        public byte[] Decrypt(byte[] bytesData, byte[] bytesKey)
        {
            if (bytesData == null)
            {
                return null;
            }
            if (bytesKey == null)
            {
                return null;
            }
            //Set up the memory stream for the decrypted data. 
            MemoryStream memStreamDecryptedData = new MemoryStream();
            //Pass in the initialization vector. 
            transformer.IV = initVec;
            ICryptoTransform transform = transformer.GetCryptoServiceProvider
                (bytesKey);
            CryptoStream decStream = new CryptoStream(memStreamDecryptedData,
                transform,
                CryptoStreamMode.Write);

            decStream.Write(bytesData, 0, bytesData.Length);

            decStream.FlushFinalBlock();
            decStream.Close();
            // Send the data back. 
            return memStreamDecryptedData.ToArray();
        } //end Decrypt 
    }
}
