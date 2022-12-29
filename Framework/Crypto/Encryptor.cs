using Framework.Crypto;
using System;
using System.IO;
using System.Security.Cryptography;

namespace Framework.Crypto
{
    internal class Encryptor
    {
        private readonly EncryptTransformer transformer;
        private byte[] initVec;
        private byte[] encKey;

        public Encryptor(EncryptionAlgorithm id)
        {
            transformer = new EncryptTransformer(id);
        }

        public byte[] IV
        {
            get { return initVec; }
            set { initVec = value; }
        }
        public byte[] Key
        {
            get { return encKey; }
        }


        public byte[] Encrypt(byte[] bytesData, byte[] bytesKey)
        {
            if (bytesData == null)
            {
                return null;
            }

            if (bytesKey == null)
            {
                return null;
            }

            //Set up the stream that will hold the encrypted data. 
            MemoryStream memStreamEncryptedData = new MemoryStream();
            transformer.IV = initVec;
            ICryptoTransform transform = transformer.GetCryptoServiceProvider
                (bytesKey);
            CryptoStream encStream = new CryptoStream(memStreamEncryptedData,
                transform,
                CryptoStreamMode.Write);
            try
            {
                //Encrypt the data, write it to the memory stream. 
                encStream.Write(bytesData, 0, bytesData.Length);
            }
            catch (Exception)
            {
                throw;
            }
            //Set the IV and key for the client to retrieve 
            encKey = transformer.Key;
            initVec = transformer.IV;
            encStream.FlushFinalBlock();
            encStream.Close();
            //Send the data back. 
            return memStreamEncryptedData.ToArray();
        }//end Encrypt 
    }
}
