using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dmmw.Api.Models
{
	public class HospitalModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IList<WaitingModel> WaitingList { get; set; }
		public LocationModel Location { get; set; }
	}
}