namespace MACDTrade.Web
{
    #region Usings

    using System;
    using System.Security.Cryptography;
    using System.Web.Security;

    #endregion
    public class Helper
    {
        #region Helper Methods

        public static string CreateSalt(int length = 9)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] byteArr = new byte[length];
            rng.GetBytes(byteArr);
            return Convert.ToBase64String(byteArr);
        }
        public static string CreatePasswordHash(string password, string salt)
        {
            string passwrodSalt = String.Concat(password, salt);
            return FormsAuthentication.HashPasswordForStoringInConfigFile(passwrodSalt, "sha1");
        }

        #endregion
    }
}