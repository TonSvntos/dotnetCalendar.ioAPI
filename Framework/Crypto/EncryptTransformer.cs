using System.Security.Cryptography;

namespace Framework.Crypto
{
    public enum EncryptionAlgorithm { Des = 1, Rc2, Rijndael, TripleDes };

    internal class EncryptTransformer
    {
        private readonly EncryptionAlgorithm algorithmID;
        private byte[] encKey;

        internal byte[] IV { get; set; }

        internal byte[] Key
        {
            get { return encKey; }
        }

        internal EncryptTransformer(EncryptionAlgorithm algId)
        {
            //Save the algorithm being used. 
            algorithmID = algId;
        }

        internal ICryptoTransform GetCryptoServiceProvider(byte[] bytesKey)
        {
            // Pick the provider. 
            switch (algorithmID)
            {
                case EncryptionAlgorithm.Des:
                    {
                        var des = new AesCryptoServiceProvider();
                        des.Mode = CipherMode.CBC;
                        // See if a key was provided 
                        if (null == bytesKey)
                        {
                            encKey = des.Key;
                        }
                        else
                        {
                            des.Key = bytesKey;
                            encKey = des.Key;
                        }
                        // See if the client provided an initialization vector 
                        if (null == this.IV)
                        { // Have the algorithm create one 
                            this.IV = des.IV;
                        }
                        else
                        { //No, give it to the algorithm 
                            des.IV = this.IV;
                        }
                        return des.CreateEncryptor();
                    }
                case EncryptionAlgorithm.TripleDes:
                    {
                        var des3 = new AesCryptoServiceProvider();
                        des3.Mode = CipherMode.CBC;
                        // See if a key was provided 
                        if (null == bytesKey)
                        {
                            encKey = des3.Key;
                        }
                        else
                        {
                            des3.Key = bytesKey;
                            encKey = des3.Key;
                        }
                        // See if the client provided an IV 
                        if (null == this.IV)
                        { //Yes, have the alg create one 
                            this.IV = des3.IV;
                        }
                        else
                        { //No, give it to the alg. 
                            des3.IV = this.IV;
                        }
                        return des3.CreateEncryptor();
                    }
                case EncryptionAlgorithm.Rc2:
                    {
                        var rc2 = new AesCryptoServiceProvider();
                        rc2.Mode = CipherMode.CBC;
                        // Test to see if a key was provided 
                        if (null == bytesKey)
                        {
                            encKey = rc2.Key;
                        }
                        else
                        {
                            rc2.Key = bytesKey;
                            encKey = rc2.Key;
                        }
                        // See if the client provided an IV 
                        if (null == this.IV)
                        { //Yes, have the alg create one 
                            this.IV = rc2.IV;
                        }
                        else
                        { //No, give it to the alg. 
                            rc2.IV = this.IV;
                        }
                        return rc2.CreateEncryptor();
                    }
                case EncryptionAlgorithm.Rijndael:
                    {
                        Rijndael rijndael = new RijndaelManaged();
                        rijndael.Mode = CipherMode.CBC;
                        // Test to see if a key was provided 
                        if (null == bytesKey)
                        {
                            encKey = rijndael.Key;
                        }
                        else
                        {
                            rijndael.Key = bytesKey;
                            encKey = rijndael.Key;
                        }
                        // See if the client provided an IV 
                        if (null == this.IV)
                        { //Yes, have the alg create one 
                            this.IV = rijndael.IV;
                        }
                        else
                        { //No, give it to the alg. 
                            rijndael.IV = this.IV;
                        }
                        return rijndael.CreateEncryptor();
                    }
                default:
                    {
                        throw new CryptographicException("Algorithm ID '" + algorithmID +
                            "' not supported.");
                    }
            }
        }
    }
}
