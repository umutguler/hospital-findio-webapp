using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Dmmw.Api.Models;
using Dmmw.Api.Utils;

namespace Hospital.Findio.Api.Controllers
{
	public class IllnessController : BaseApiController
	{
		private readonly IHttpClientFactory _clientFactory;
		public IllnessController(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
		}

		// Gets all illnesses as one list
		[HttpGet("illnesses")]
		public async Task<ActionResult<IEnumerable<IllnessModel>>> GetIllnesses()
		{
			var client = _clientFactory.CreateClient("dmmw");
			var illnesses = (await DmmwHelper.GetEmbeddedList<IllnessContainerModel>(client, "illnesses"))
											 .Select(i => i.Illness)
											 .ToList();
			return illnesses;
		}
	}
}