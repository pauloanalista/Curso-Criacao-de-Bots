using System;

namespace Bot.Instagram.Profile
{
    class Program
    {
        static void Main(string[] args)
        {
            Profile profile = Instagram.GetProfileByUser("paulorogerio_oficial");

            Console.WriteLine($"UserName = {profile.UserName}");
            Console.WriteLine($"Title = {profile.Title}");
            Console.WriteLine($"Description = {profile.Description}");
            Console.WriteLine($"Url = {profile.Url}");
            Console.WriteLine($"Image = {profile.Image}");
            Console.WriteLine($"AndroidAppId = {profile.AndroidAppId}");
            Console.WriteLine($"AndroidAppName = {profile.AndroidAppName}");
            Console.WriteLine($"AndroidUrl = {profile.AndroidUrl}");
            Console.WriteLine($"IosAppId = {profile.IosAppId}");
            Console.WriteLine($"IosAppName = {profile.IosAppName}");
            Console.WriteLine($"IosUrl = {profile.IosUrl}");
            Console.ReadKey();
        }
    }
}
