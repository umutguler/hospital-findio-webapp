using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Findio.Api.Entities
{
	public class Patient
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		[MinLength(4)]
		[RegularExpression(@"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$")]
		public string Name { get; set; }
		[Required]
		[Range(0, 4)]
		public int? LevelOfPain { get; set; }
		[Required]
		[Range(0, int.MaxValue)]
		public int? IllnessId { get; set; }
	}
}