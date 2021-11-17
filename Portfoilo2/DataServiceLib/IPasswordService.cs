namespace DataServiceLib
{
    public interface IPasswordService
    {
        public void CreatePwdHash(string plainTxtPwd, out byte[] pwdHash, out byte[] pwdSalt);
        public bool VerifyPwdHash(string plainTxtPwd, byte[] pwdHash, byte[] pwdSalt);
    }
}
