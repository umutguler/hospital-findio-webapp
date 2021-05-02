using System.Collections.Generic;
using Dmmw.Api.Utils;
using Newtonsoft.Json;


namespace Dmmw.Api.Models
{

	[JsonConverter(typeof(DmmwJsonPathConverter))]
	public class DmmwRootModel
	{
		[JsonExtensionData]
		public Dictionary<string, object> Data { get; set; }
		public LinkModel Link { get; set; }
		public PageModel Page { get; set; }
	}
}