using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib
{
    public interface IPasswordService
    {
        public void CreatePwdHash(string plainTxtPwd, out byte[] pwdHash, out byte[] pwdSalt);
        public bool VerifyPwdHash(string plainTxtPwd, byte[] pwdHash, byte[] pwdSalt);
    }
}
