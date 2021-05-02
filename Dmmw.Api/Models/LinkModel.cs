using System.Text.Json.Serialization;

namespace Dmmw.Api.Models
{
	public class LinkModel
	{
		[JsonPropertyName("self")]
		public HrefModel Self { get; set; }
	}
}