using Newtonsoft.Json;

namespace Dmmw.Api.Models
{
	public class IllnessContainerModel
	{
		public IllnessModel Illness { get; set; }
		[JsonProperty("_links")]
		public LinkModel Link { get; set; }
	}
}