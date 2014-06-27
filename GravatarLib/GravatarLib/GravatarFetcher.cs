using System;
using MonoMac.AppKit;
using MonoMac.Foundation;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace GravatarLib
{
    public class GravatarFetcher
    {
        async public Task<NSImage> GetGravatar(string email)
        {
            var url = GetUrlFromEmailAddress(email);
            var webclient = new System.Net.WebClient();
            var imageBytes = await webclient.DownloadDataTaskAsync(new Uri(url));
            NSImage image = null;
            try 
            {

                image = new NSImage(NSData.FromArray(imageBytes));
                imageBytes = null;
            } 
            catch (Exception ) 
            {
                return null;
            }

            return image;
        }

        private static string GetUrlFromEmailAddress(string email)
        {
            if (email == "")
            {
                throw new ArgumentException("Email cannot be empty", email);
            }
            return "http://www.gravatar.com/avatar/" + CreateHash(email) + "?s=128";
        }

        private static string CreateHash(string email)
        {
            if (email == "")
            {
                throw new ArgumentException("Email address cannot be empty", email);
            }
            return GetMd5Hash(email.Trim().ToLower());
        }

        private static string GetMd5Hash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input));

            var sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString().ToLower();
        }
    }
}

