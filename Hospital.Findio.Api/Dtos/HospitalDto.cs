using Dmmw.Api.Models;

namespace Hospital.Findio.Api.Dtos
{
	public class HospitalDto
	{
		public int Id { get; set; }
		public int LevelOfPain { get; set; }
		public string Name { get; set; }
		public int PatientCount { get; set; }
		public int AverageProcessTime { get; set; }
		public int WaitingTime { get; set; }
		public LocationModel Location { get; set; }
	}
}