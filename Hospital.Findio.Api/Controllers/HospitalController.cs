using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dmmw.Api.Models;
using Dmmw.Api.Utils;
using Hospital.Findio.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Findio.Api.Controllers
{
	public class HospitalController : BaseApiController
	{
		private readonly IHttpClientFactory _clientFactory;
		public HospitalController(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
		}

		[HttpGet("hospitals")]
		public async Task<ActionResult<IEnumerable<HospitalModel>>> GetHospitals()
		{
			var client = _clientFactory.CreateClient("dmmw");
			var hospitals = (await DmmwHelper.GetEmbeddedList<HospitalModel>(client, "hospitals"))
											 .ToList();
			return hospitals;
		}

		[HttpGet("hospitals/fastest")]
		public async Task<ActionResult<IEnumerable<HospitalDto>>> GetFastestHospitals([FromQuery] FastestQueryDto query)
		{
			var client = _clientFactory.CreateClient("dmmw");
			var _hospitals = (await DmmwHelper.GetEmbeddedList<HospitalModel>(client, "hospitals"));

			List<HospitalDto> hospitals = new List<HospitalDto>();

			foreach (var hospital in _hospitals)
			{
				WaitingModel waiting = hospital.WaitingList
											   .Where(w => w.LevelOfPain == query.LevelOfPain.Value)
											   .Single();
				int waitingTime = waiting.PatientCount * waiting.AverageProcessTime;

				HospitalDto _hospital = new HospitalDto
				{
					Id = hospital.Id,
					Name = hospital.Name,
					LevelOfPain = query.LevelOfPain.Value,
					AverageProcessTime = waiting.AverageProcessTime,
					PatientCount = waiting.PatientCount,
					WaitingTime = waitingTime,
					Location = hospital.Location
				};

				hospitals.Add(_hospital);
			}

			return hospitals.OrderBy(h => h.WaitingTime).ToList();
		}
	}
}