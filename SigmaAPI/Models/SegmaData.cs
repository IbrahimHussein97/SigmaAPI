using Microsoft.AspNetCore.Routing;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SigmaAPI.Models
{
    public class SegmaData
    {
        [Column("First name")]
        public string Firstname { get; set; }
        [Column("Last name")]
        public string Lastname { get; set; }
        [Column("Phone number")]
        public string Phonenumber { get; set; }
        public string Email { get; set; }

        [Column("Time interval")]
        public string Timeinterval { get; set; }
        [Column("LinkedIn profile URL")]
        public string LinkedInprofileURL { get; set; }
        [Column("GitHub profile URL")]
        public string GitHubprofileURL { get; set; }
        [Column("GitHub profile URL")]
        public string Freetextcomment{ get; set; }
    }
}
