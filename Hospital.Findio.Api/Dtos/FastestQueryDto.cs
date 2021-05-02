using System.ComponentModel.DataAnnotations;

namespace Hospital.Findio.Api.Dtos
{
	public class FastestQueryDto
	{
		[Required]
		[Range(0, 4)]
		public int? LevelOfPain { get; set; }
	}
}