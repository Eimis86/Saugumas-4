using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Saugumas4
{
    internal class AES
    {
        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    rng.GetBytes(data);
                }
            }

            return data;
        }

        public static void FileEncrypt(string inputFile, string password)
        {
            byte[] salt = GenerateRandomSalt();

            using (FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create))
            {
                byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

                RijndaelManaged AES = new RijndaelManaged();
                AES.KeySize = 256;
                AES.BlockSize = 128;
                AES.Padding = PaddingMode.PKCS7;

                var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000); // Iterations to derive key
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);

                AES.Mode = CipherMode.CFB;

                fsCrypt.Write(salt, 0, salt.Length);

                using (CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    //C:\Users\Eimucio\Desktop\Studijos\2 metai antras pusmetis\Informacijos saugumas\Saugumas4\Saugumas4\bin\Debug\db.txt
                    using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                    {
                        byte[] buffer = new byte[1048576];
                        int read;
                        // read = buffer.Length;
                        try
                        {
                            while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                Application.DoEvents();
                                cs.Write(buffer, 0, read);
                            }
                            fsIn.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error FileEncrypt: " + ex.Message);
                        }
                        finally
                        {
                            cs.Close();
                            fsCrypt.Close();
                        }
                    };
                };
            };
        }

        public static void FileDecrypt(string inputFile, string outputFile, string password)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                   // Application.DoEvents();

                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
            }
            finally
            {
                cs.Close();
                fsOut.Close();
                fsCrypt.Close();
            }
        }

        //BCrypt
        private static string RandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public static string HashPassword(string cryptedpass)
        {
            return BCrypt.Net.BCrypt.HashPassword(cryptedpass, RandomSalt());
        }

        /*public static string Decrypt(string cryptedpass)
        {
           
        }*/

        public static bool ValidatePassword(string cryptedpass, string koksturibut)
        {
            return BCrypt.Net.BCrypt.Verify(cryptedpass, koksturibut);
        }

    }
}
