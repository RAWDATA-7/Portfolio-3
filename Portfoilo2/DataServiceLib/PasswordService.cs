using System.Text;
using System.Security.Cryptography;

namespace DataServiceLib
{
    public class PasswordService : IPasswordService
    {
        public  void CreatePwdHash(string plainTxtPwd, out byte[] pwdHash, out byte[] pwdSalt)
        {
            var hmac = new HMACSHA512();
            pwdSalt = hmac.Key;
            pwdHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(plainTxtPwd));
        }

        public  bool VerifyPwdHash(string plainTxtPwd, byte[] pwdHash, byte[] pwdSalt)
        {
            var hmac = new HMACSHA512(pwdSalt);
            var computeHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(plainTxtPwd));

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
