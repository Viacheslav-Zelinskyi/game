using System;
using System.Text;
using System.Security.Cryptography;

namespace game
{
    class HMACGenerator
    {
        static private byte[] key = new Byte[16];
        static public string[] getHMAC(string message)
        {
            RandomNumberGenerator.Create().GetBytes(key);
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                string[] result = { Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(message))), Convert.ToHexString(key) };
                return result;
            }
        }
    }
}