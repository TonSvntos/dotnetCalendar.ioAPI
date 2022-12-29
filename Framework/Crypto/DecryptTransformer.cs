using System.Security.Cryptography;

namespace Framework.Crypto
{
    internal class DecryptTransformer
    {
        private readonly EncryptionAlgorithm algorithmId;
        private byte[] _initVec;

        internal byte[] IV
        {
            private get { return _initVec; }
            set { _initVec = value; }
        }

        internal DecryptTransformer(EncryptionAlgorithm deCryptId)
        {
            algorithmId = deCryptId;
        }

        internal ICryptoTransform GetCryptoServiceProvider(byte[] bytesKey)
        {
            // Pick the provider. 
            switch (algorithmId)
            {
                case EncryptionAlgorithm.Des:
                    {
                        var des = new AesCryptoServiceProvider();
                        des.Mode = CipherMode.CBC;
                        des.Key = bytesKey;
                        des.IV = _initVec;
                        return des.CreateDecryptor();
                    }
                case EncryptionAlgorithm.TripleDes:
                    {
                        var des3 = new AesCryptoServiceProvider();
                        des3.Mode = CipherMode.CBC;
                        return des3.CreateDecryptor(bytesKey, _initVec);
                    }
                case EncryptionAlgorithm.Rc2:
                    {
                        var rc2 = new AesCryptoServiceProvider();
                        rc2.Mode = CipherMode.CBC;
                        return rc2.CreateDecryptor(bytesKey, _initVec);
                    }
                case EncryptionAlgorithm.Rijndael:
                    {
                        Rijndael rijndael = new RijndaelManaged();
                        rijndael.Mode = CipherMode.CBC;
                        return rijndael.CreateDecryptor(bytesKey, _initVec);
                    }
                default:
                    {
                        throw new CryptographicException("Algorithm ID '" + algorithmId +
                            "' not supported.");
                    }
            }
        } //end GetCryptoServiceProvider
    }
}
