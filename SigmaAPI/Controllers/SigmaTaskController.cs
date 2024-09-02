using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SigmaAPI.Models;
using SigmaAPI.repository;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SigmaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SigmaTaskController : ControllerBase
    {

        public static string filepath = Path.Combine( "Contents", "Sigma.csv");
        public static string[] headers = ["First name", "Last name", "Phone number", "Email", "Time interval when it’s better to call (in case a call is needed)", "LinkedIn profile URL", "GitHub profile URL", "Free text commen"];

        SigmaService _service = new SigmaService(filepath, headers);
        [HttpPost]
        public  async Task<IActionResult> SaveData(SegmaData _segmaData)
        { 
            bool isHaveHeader = await _service.CreateHeader();
            var isAction = _service.checkIfExistRecordOrNew(_segmaData);
            var c=_service.UpdateOrSave(isAction);
            return Ok();
        }
        
    }
}
