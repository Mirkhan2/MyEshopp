using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyEshopp.Controllers
{
	[Authorize]
	public class TestController : Controller
	{
		public string Test1()
		{
			return "Test 1";
		}

		//[AllowAnonymous] 
		public string Test2()
		{
			return "Test2";
		}
	}
}
