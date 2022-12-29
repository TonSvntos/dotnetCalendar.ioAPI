using Framework.Crypto;
using System;
using System.Text;

namespace Framework.Crypto
{
    public class SCriptografia
    {
        public string Criptografar(string strDados)
        {
            //Parte de criptografia
            EncryptionAlgorithm algorithm = EncryptionAlgorithm.Rijndael;
            // Inicializa variavel. 
            byte[] IV = null;
            byte[] cipherText = null;
            byte[] key = null;
            try
            { //Try to encrypt. 
              //Create the encryptor. 
                Encryptor enc = new Encryptor(EncryptionAlgorithm.Rijndael);
                byte[] plainText = Encoding.ASCII.GetBytes(strDados);

                if ((EncryptionAlgorithm.TripleDes == algorithm) ||
                    (EncryptionAlgorithm.Rijndael == algorithm))
                { //3Des only work with a 16 or 24 byte key. 
                    key = Encoding.ASCII.GetBytes("wrefdhetdhwyehdeyehdqwse");
                    IV = (EncryptionAlgorithm.Rijndael == algorithm) ? Encoding.ASCII.GetBytes("ehdlrodjewierdwq") : Encoding.ASCII.GetBytes("init vec");
                }
                else
                {   //Des only works with an 8 byte key. The others uses variable length keys. 
                    //Set the key to null to have a new one generated. 
                    key = Encoding.ASCII.GetBytes("password");
                    IV = Encoding.ASCII.GetBytes("init vec");
                }
                // Uncomment the next lines to have the key or IV generated for you. 
                enc.IV = IV;
                // Perform the encryption. 
                cipherText = enc.Encrypt(plainText, key);
                // Retrieve the intialization vector and key. You will need it  
                // for decryption. 
                IV = enc.IV;
                key = enc.Key;
                // Look at your cipher text and initialization vector. 
                return Convert.ToBase64String(cipherText);
            }
            catch
            {
                return strDados;
            }
        }
        public string Descriptografar(string strDados)
        {
            //Parte de criptografia
            EncryptionAlgorithm algorithm = EncryptionAlgorithm.Rijndael;
            // Inicializa variavel. 
            byte[] IV = null;
            byte[] cipherText = null;
            byte[] key = null;

            try
            { //Try to decrypt. 
              //Set up your decryption, give it the algorithm and initialization vector. 
                Decryptor dec = new Decryptor(algorithm);
                cipherText = Convert.FromBase64String(strDados);
                if ((EncryptionAlgorithm.TripleDes == algorithm) ||
                    (EncryptionAlgorithm.Rijndael == algorithm))
                { //3Des only work with a 16 or 24 byte key. 
                    key = Encoding.ASCII.GetBytes("wrefdhetdhwyehdeyehdqwse");
                    IV = (EncryptionAlgorithm.Rijndael == algorithm) ? Encoding.ASCII.GetBytes("ehdlrodjewierdwq") : Encoding.ASCII.GetBytes("init vec");
                }
                else
                {   //Des only works with an 8 byte key. The others uses variable length keys. 
                    //Set the key to null to have a new one generated. 
                    key = Encoding.ASCII.GetBytes("password");
                    IV = Encoding.ASCII.GetBytes("init vec");

                }
                dec.IV = IV;
                // Go ahead and decrypt. 
                byte[] plainText = dec.Decrypt(cipherText, key);

                // Look at your plain text. 
                return Encoding.ASCII.GetString(plainText);
            }
            catch
            {
                return strDados;
            }
        }
    }
}
