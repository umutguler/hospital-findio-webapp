using System;
using System.Collections.Generic;
using Dmmw.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dmmw.Api.Utils
{
	// Custom JSONConverter for DMMW api JSON's root object 
	public class DmmwJsonPathConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(DmmwRootModel) == objectType;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (!CanConvert(objectType)) return null;

			JObject jObject = JObject.Load(reader);

			DmmwRootModel root = new DmmwRootModel()
			{
				Data = jObject["_embedded"].ToObject<Dictionary<string, object>>(),
				Link = jObject["_links"].ToObject<LinkModel>(),
				Page = jObject["page"].ToObject<PageModel>()
			};

			return root;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}