using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string JwtToken = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI1IiwidW5pcXVlX25hbWUiOiJtZWhtZXQiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE1Mzk3NjQxMTAsImV4cCI6MTUzOTg1MDQ2NSwiaWF0IjoxNTM5NzY0MTEwfQ.5T9XTAWQwtmZsLznGHcRtmzJ_Vksv3JzdvCYJR4bFYJU1ckHcisW4dTzWS0UdOlmf4rKDeuMOx4_zXD6SO6vrw";
            int start = JwtToken.IndexOf(".") + 1;
            int end = JwtToken.LastIndexOf(".");
            var tokenString = JwtToken.Substring(start, end - start).Split('.');
            
            string token = tokenString[0].ToString()+"==";
            var converted = Convert.FromBase64String(token);

            var credentialString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            // Splitting the password from username
            var credentials = credentialString.Split(new char[] { ':', ',' });

            // Trim this string.
            var userRule = credentials[5].Replace("\"", "");
            var userName = credentials[3].Replace("\"", "");
            Console.WriteLine($"UserName :{userName}");
            Console.WriteLine($"UserRule :{userRule}");
            Console.ReadKey();

        }

        
    }
}
