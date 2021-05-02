using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dmmw.Api.Models;
using Newtonsoft.Json;

namespace Dmmw.Api.Utils
{
	// Helper functions for DmmwApi embedded
	public static class DmmwHelper
	{
		/*
	 	 * This function is designed around the way the DMMW api packages the JSON data underneath the "embedded" property
	 	 * The embedded property contains some form of array[objects], and while there are only two methods
		 * (illnesses and hospitals), we can assume that any subsequent types of data underneath embedded is similar
 		 */
		// Stitches the paginated data payload of "embedded" into one list
		// Returns a generic IEnumerable<T> where T is the object model of the JSON object
		public static async Task<IEnumerable<T>> GetEmbeddedList<T>(HttpClient client, string route)
		{
			List<T> embeddedList = new List<T>();
			HttpResponseMessage response;
			int totalPages = 0;
			int page = 0;

			do
			{
				try
				{
					string requestUri = String.Format("{0}?limit=20&page={1}", route, page);
					response = await client.GetAsync(requestUri);
					response.EnsureSuccessStatusCode();
				}
				catch (System.Exception)
				{
					throw;
				}

				string body = await response.Content.ReadAsStringAsync();
				DmmwRootModel rootModel = JsonConvert.DeserializeObject<DmmwRootModel>(body);
				totalPages = rootModel.Page.TotalPages;
				IEnumerable<T> _list = JsonConvert.DeserializeObject<IEnumerable<T>>(rootModel.Data[route].ToString());
				embeddedList.AddRange(_list);

				page++;
			} while (page <= totalPages);

			return embeddedList;
		}
	}
}