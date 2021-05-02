using Xunit;
using Hospital.Findio.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Diagnostics;
using System.Net;

namespace Hospital.Findio.Api.Controllers.Tests
{
	public class IllnessControllerTests
	{
		private readonly HttpClient _client;
		public IllnessControllerTests()
		{
			var appFactory = new WebApplicationFactory<Startup>();
			_client = appFactory.CreateClient();
		}

		[Fact()]
		public void GetIllnesses_StatusCodeOk_Test()
		{
			var response = _client.GetAsync("api/illness/illnesses");

			Assert.Equal(HttpStatusCode.OK, response.Result.StatusCode);
		}

		[Fact()]
		public void GetIllnesses_JsonIsEqual_Test()
		{
			string json = "[{\"id\":1,\"name\":\"Mortal Cold\"},{\"id\":2,\"name\":\"Happy Euphoria\"},{\"id\":3,\"name\":\"Withering Parasite\"},{\"id\":4,\"name\":\"Death's Delusions\"},{\"id\":5,\"name\":\"Intense Intolerance\"},{\"id\":6,\"name\":\"Whispering Hepatitis\"},{\"id\":7,\"name\":\"Spirit Parasite\"},{\"id\":8,\"name\":\"Crippling Paranoia\"},{\"id\":9,\"name\":\"Sheep Sneeze\"},{\"id\":10,\"name\":\"Impossible Ebola\"},{\"id\":11,\"name\":\"Cow Acne\"},{\"id\":12,\"name\":\"Devil's Finger\"},{\"id\":13,\"name\":\"Delirious Insanity\"},{\"id\":14,\"name\":\"Contagious Measles\"},{\"id\":15,\"name\":\"Lady Euphoria\"}]";
			Task<HttpResponseMessage> response = _client.GetAsync("api/illness/illnesses");

			Assert.Equal(json, response.Result.Content.ReadAsStringAsync().Result);
		}
	}
}