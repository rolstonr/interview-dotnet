using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace interview_dotnet.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        MyFileSystem _fileSystem = new MyFileSystem();

        [Route("path")]
        [HttpGet]
        public List<ICustomer> Get(string filename)
        {
            return _fileSystem.ReadData(filename);
        }
        [Route("add customer")]
        [HttpPost]
        public void Post(string filename, Customer cust)
        {
            _fileSystem.SaveData(filename, cust);
        }
    }
}
