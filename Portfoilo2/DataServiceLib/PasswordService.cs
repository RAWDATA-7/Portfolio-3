using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataServiceLib
{
    class PasswordService
    {
        public void CreatePwdHash(string plainTxtPwd, out byte[] pwdHash, out byte[] pwdSalt)
        {
            var hmac = new HMACSHA512();
            pwdSalt = hmac.Key;
            pwdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(plainTxtPwd));
        }

        public bool VerifyPwdHash(string plainTxtPwd, byte[] pwdHash, byte[] pwdSalt)
        {
            var hmac = new HMACSHA512(pwdSalt);
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(plainTxtPwd));

            for(int i = 0; i < computeHash.Length; i++)
            {
                if(!(computeHash[i] == pwdHash[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
