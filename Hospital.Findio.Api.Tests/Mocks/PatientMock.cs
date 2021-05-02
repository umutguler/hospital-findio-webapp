using Hospital.Findio.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Findio.Api.Tests.Mocks
{
	class PatientMock
	{
		public readonly List<Patient> patients;

		public PatientMock()
		{
			patients = new List<Patient>()
			{
				new Patient(){Id = 1, Name = "John Smith", IllnessId = 0, LevelOfPain = 2 },
				new Patient(){Id = 2, Name = "John D'Largy", IllnessId = 1, LevelOfPain = 2 },
				new Patient(){Id = 3, Name = "John Doe-Smith", IllnessId = 2, LevelOfPain = 1 },
				new Patient(){Id = 4, Name = "John Doe Smith", IllnessId = 3, LevelOfPain = 0 },
				new Patient(){Id = 5, Name = "Hector Sausage-Hausen", IllnessId = 5, LevelOfPain = 1 },
				new Patient(){Id = 6, Name = "Mathias d'Arras", IllnessId = 10, LevelOfPain = 2 },
				new Patient(){Id = 7, Name = "Martin Luther King", IllnessId = 1, LevelOfPain = 2 },
				new Patient(){Id = 8, Name = "Ai Wong", IllnessId = 2, LevelOfPain = 3 },
				new Patient(){Id = 9, Name = "Chao Chang", IllnessId = 3, LevelOfPain = 4 },
				new Patient(){Id = 10, Name = "Alzbeta Bara", IllnessId = 2, LevelOfPain = 2 },
				new Patient(){Id = 11, Name = "Test User", IllnessId = 4, LevelOfPain = 1 },
				new Patient(){Id = 12, Name = "Test User", IllnessId = 15, LevelOfPain = 0 },
			};
		}
	}
}









