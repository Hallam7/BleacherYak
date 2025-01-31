﻿using System;
using Newtonsoft.Json;

namespace BleacherYak.AuthHelpers
{
	[JsonObject]
	public class User
    {
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("given_name")]
		public string GivenName { get; set; }

		[JsonProperty("family_name")]
		public string FamilyName { get; set; }

	}
}
