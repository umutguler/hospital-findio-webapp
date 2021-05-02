using System.Text.Json.Serialization;

namespace Dmmw.Api.Models
{
	public class HrefModel
	{
		[JsonPropertyName("href")]
		public string Href { get; set; }
	}
}