using Xunit;
using Hospital.Findio.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Diagnostics;
using System.Net;

namespace Hospital.Findio.Api.Controllers.Tests
{
	public class HospitalControllerTests
	{
		private HttpClient _client;

		public HospitalControllerTests()
		{
			var appFactory = new WebApplicationFactory<Startup>();
			_client = appFactory.CreateClient();
		}

		[Fact()]
		public void GetFastestHospitals_JsonIsEqual_Test()
		{
			string json = "[{\"id\":2,\"levelOfPain\":0,\"name\":\"Royal Prince Alfred Hospital\",\"patientCount\":0,\"averageProcessTime\":60,\"waitingTime\":0,\"location\":{\"lat\":-33.889406,\"lng\":151.183488}},{\"id\":5,\"levelOfPain\":0,\"name\":\"Prince of Wales Hospital\",\"patientCount\":0,\"averageProcessTime\":23,\"waitingTime\":0,\"location\":{\"lat\":-33.91851,\"lng\":151.23897}},{\"id\":19,\"levelOfPain\":0,\"name\":\"Campbelltown Hospital\",\"patientCount\":0,\"averageProcessTime\":41,\"waitingTime\":0,\"location\":{\"lat\":-34.079849,\"lng\":150.803375}},{\"id\":18,\"levelOfPain\":0,\"name\":\"Mount Druitt Hospital\",\"patientCount\":1,\"averageProcessTime\":22,\"waitingTime\":22,\"location\":{\"lat\":-33.764752,\"lng\":150.827445}},{\"id\":10,\"levelOfPain\":0,\"name\":\"Auburn Hospital & Community Health Services\",\"patientCount\":1,\"averageProcessTime\":36,\"waitingTime\":36,\"location\":{\"lat\":-33.860402,\"lng\":151.03362}},{\"id\":6,\"levelOfPain\":0,\"name\":\"Ryde Hospital\",\"patientCount\":1,\"averageProcessTime\":40,\"waitingTime\":40,\"location\":{\"lat\":-33.796271,\"lng\":151.089709}},{\"id\":16,\"levelOfPain\":0,\"name\":\"Liverpool Hospital\",\"patientCount\":1,\"averageProcessTime\":46,\"waitingTime\":46,\"location\":{\"lat\":-33.920356,\"lng\":150.929298}},{\"id\":8,\"levelOfPain\":0,\"name\":\"St George Hospital\",\"patientCount\":5,\"averageProcessTime\":11,\"waitingTime\":55,\"location\":{\"lat\":-33.965493,\"lng\":151.134032}},{\"id\":22,\"levelOfPain\":0,\"name\":\"Shellharbour Hospital\",\"patientCount\":7,\"averageProcessTime\":8,\"waitingTime\":56,\"location\":{\"lat\":-34.559028,\"lng\":150.841048}},{\"id\":4,\"levelOfPain\":0,\"name\":\"Sydney Children's Hospital\",\"patientCount\":2,\"averageProcessTime\":30,\"waitingTime\":60,\"location\":{\"lat\":-33.917286,\"lng\":151.23767}},{\"id\":17,\"levelOfPain\":0,\"name\":\"Blacktown Hospital\",\"patientCount\":7,\"averageProcessTime\":19,\"waitingTime\":133,\"location\":{\"lat\":-33.7769,\"lng\":150.917301}},{\"id\":12,\"levelOfPain\":0,\"name\":\"Sutherland Hospital & Community Health Service\",\"patientCount\":9,\"averageProcessTime\":15,\"waitingTime\":135,\"location\":{\"lat\":-34.036834,\"lng\":151.116591}},{\"id\":1,\"levelOfPain\":0,\"name\":\"St Vincent's Hospital\",\"patientCount\":10,\"averageProcessTime\":20,\"waitingTime\":200,\"location\":{\"lat\":-33.880409,\"lng\":151.220958}},{\"id\":7,\"levelOfPain\":0,\"name\":\"Concord Repatriation General Hospital\",\"patientCount\":5,\"averageProcessTime\":42,\"waitingTime\":210,\"location\":{\"lat\":-33.835132,\"lng\":151.096655}},{\"id\":9,\"levelOfPain\":0,\"name\":\"Northern Beaches Hospital\",\"patientCount\":10,\"averageProcessTime\":21,\"waitingTime\":210,\"location\":{\"lat\":-33.7504,\"lng\":151.2326}},{\"id\":11,\"levelOfPain\":0,\"name\":\"Canterbury Hospital\",\"patientCount\":9,\"averageProcessTime\":25,\"waitingTime\":225,\"location\":{\"lat\":-33.9196,\"lng\":151.0984}},{\"id\":3,\"levelOfPain\":0,\"name\":\"Royal North Shore Hospital\",\"patientCount\":4,\"averageProcessTime\":75,\"waitingTime\":300,\"location\":{\"lat\":-33.820992,\"lng\":151.191415}},{\"id\":20,\"levelOfPain\":0,\"name\":\"Gosford Hospital\",\"patientCount\":4,\"averageProcessTime\":76,\"waitingTime\":304,\"location\":{\"lat\":-33.419599,\"lng\":151.340264}},{\"id\":23,\"levelOfPain\":0,\"name\":\"Sydney Hospital & Sydney Eye Hospital\",\"patientCount\":5,\"averageProcessTime\":92,\"waitingTime\":460,\"location\":{\"lat\":-33.868919,\"lng\":151.212122}},{\"id\":15,\"levelOfPain\":0,\"name\":\"Fairfield Hospital\",\"patientCount\":9,\"averageProcessTime\":55,\"waitingTime\":495,\"location\":{\"lat\":-33.857382,\"lng\":150.9043}},{\"id\":14,\"levelOfPain\":0,\"name\":\"Bankstown Lidcombe Hospital\",\"patientCount\":9,\"averageProcessTime\":58,\"waitingTime\":522,\"location\":{\"lat\":-33.931975,\"lng\":151.02141}},{\"id\":13,\"levelOfPain\":0,\"name\":\"Hornsby Ku-ring-gai Hospital\",\"patientCount\":18,\"averageProcessTime\":32,\"waitingTime\":576,\"location\":{\"lat\":-33.701761,\"lng\":151.113038}},{\"id\":21,\"levelOfPain\":0,\"name\":\"Wollongong Hospital\",\"patientCount\":11,\"averageProcessTime\":73,\"waitingTime\":803,\"location\":{\"lat\":-34.42442,\"lng\":150.884}}]";
			Task<HttpResponseMessage> response = _client.GetAsync("/api/hospital/hospitals/fastest?levelOfPain=0");

			Assert.Equal(json, response.Result.Content.ReadAsStringAsync().Result);
		}

		[Fact()]
		public void GetFastestHospitals_LevelOfPainMinPass_Test()
		{
			Task<HttpResponseMessage> response = _client.GetAsync("/api/hospital/hospitals/fastest?levelOfPain=0");
			Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
		}

		[Fact()]
		public void GetFastestHospitals_LevelOfPainMinFail_Test()
		{
			Task<HttpResponseMessage> response = _client.GetAsync("/api/hospital/hospitals/fastest?levelOfPain=-1");
			Assert.Equal(HttpStatusCode.BadRequest, response.Result.StatusCode);
		}

		[Fact()]
		public void GetFastestHospitals_LevelOfPainMaxPass_Test()
		{
			Task<HttpResponseMessage> response = _client.GetAsync("/api/hospital/hospitals/fastest?levelOfPain=4");
			Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
		}

		[Fact()]
		public void GetFastestHospitals_LevelOfPainMaxFail_Test()
		{
			Task<HttpResponseMessage> response = _client.GetAsync("/api/hospital/hospitals/fastest?levelOfPain=5");
			Assert.Equal(HttpStatusCode.BadRequest, response.Result.StatusCode);
		}
	}
}