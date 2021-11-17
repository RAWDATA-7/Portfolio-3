using System.Linq;
using DataServiceLib;
using Xunit;

namespace XUnitTest
{
    public class DataLayerTest
    {

        [Fact]
        public void GetActorFromDatabase()
        {
            var service = new DataService();
            var actor = service.GetActor("nm0185819");

            Assert.Equal("Daniel Craig", actor.Name);
        }

        [Fact]
        public void GetActorProfessionFromDatabase_LinqExpressionCall()
        {
            var service = new DataService();
            var actor = service.GetActor("nm0185819");

            Assert.Equal("Daniel Craig", actor.Name);
            Assert.Equal(3, actor.Professions.Count);
            Assert.Equal("actor", actor.Professions.ToArray().First().Name);
        }

        [Fact]
        public void CheckPasswordService()
        {
            var pwservice = new PasswordService();
            byte[] pwdHash;
            byte[] pwdSalt;
            pwservice.CreatePwdHash("Password", out pwdHash, out pwdSalt);

            Assert.NotNull(pwdHash);
            Assert.NotNull(pwdSalt);
            Assert.True(pwservice.VerifyPwdHash("Password", pwdHash, pwdSalt));
            Assert.False(pwservice.VerifyPwdHash("Password123", pwdHash, pwdSalt));

        }
    }
}
