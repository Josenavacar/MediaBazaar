using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace MediaBazaarSystem
{
    public class Cryptography
    {
        /**
         * Making use of the AES encryption algorithm wherein a Symmetric (Same) key for encryption and decryption process is being used.
         * Firstly the original text i.e. clear text is converted into bytes and 
         * then for the AES algorithm to perform encryption, we need to generate Key and IV using the derived bytes and the symmetric key.
         * Using MemoryStream and CryptoStream the clear text is encrypted and 
         * written to byte array and finally the byte array is converted to Base64String 
         * and returned which is the final outcome i.e. the corresponding encrypted text.
         */
        public static string Encrypt( string encryptString )
        {
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement    
            byte[] clearBytes = Encoding.Unicode.GetBytes( encryptString );
            using( Aes encryptor = Aes.Create() )
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes( EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        } );
                encryptor.Key = pdb.GetBytes( 32 );
                encryptor.IV = pdb.GetBytes( 16 );
                using( MemoryStream ms = new MemoryStream() )
                {
                    using( CryptoStream cs = new CryptoStream( ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write ) )
                    {
                        cs.Write( clearBytes, 0, clearBytes.Length );
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String( ms.ToArray() );
                }
            }
            return encryptString;
        }


        /**
         * Firstly the encrypted text i.e. cipher text is converted into bytes and 
         * then similar to the encryption process here too a key and IV will be generated using the derived bytes and the symmetric key.
         * Using MemoryStream and CryptoStream the cipher text is decrypted and 
         * written to byte array and finally the byte array is converted to Base64String and returned, which is the decrypted original text.
         */
        public static string Decrypt( string cipherText )
        {
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement, but the decryption key should be same as encryption key    
            cipherText = cipherText.Replace( " ", "+" );
            byte[] cipherBytes = Convert.FromBase64String( cipherText );
            using( Aes encryptor = Aes.Create() )
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes( EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        } );
                encryptor.Key = pdb.GetBytes( 32 );
                encryptor.IV = pdb.GetBytes( 16 );
                using( MemoryStream ms = new MemoryStream() )
                {
                    using( CryptoStream cs = new CryptoStream( ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write ) )
                    {
                        cs.Write( cipherBytes, 0, cipherBytes.Length );
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString( ms.ToArray() );
                }
            }
            return cipherText;
        }
    }
}
