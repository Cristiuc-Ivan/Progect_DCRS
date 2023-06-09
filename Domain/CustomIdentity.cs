using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain
{
    public class CustomIdentity : IIdentity
    {
        // Properties from IIdentity interface
        public string AuthenticationType { get; }
        public bool IsAuthenticated { get; }
        public string Name { get; }

        // Custom properties specific to your application
        public string ProfilePic { get; }

        // Constructor
        public CustomIdentity(string name, bool isAuthenticated, string avatar)
        {
            AuthenticationType = "CustomAuthentication"; // Set your own authentication type
            IsAuthenticated = isAuthenticated;
            Name = name;

            ProfilePic = avatar;
        }
    }
}