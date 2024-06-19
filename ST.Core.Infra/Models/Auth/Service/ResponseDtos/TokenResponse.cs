﻿using System.Text.Json.Serialization;

namespace ST.Core.Infra.Models.Auth.Service.ResponseDtos
{
	/// <summary> This is received when a user requests a token </summary>
	public class TokenResponse
	{
		[JsonPropertyName("access_token")]
		public string AccessToken { get; set; }

		[JsonPropertyName("expires_in")]
		public int ExpiresInSeconds { get; set; }

		[JsonPropertyName("refresh_expires_in")]
		public int RefreshExpiresInSeconds { get; set; }

		[JsonPropertyName("token_type")]
		public string TokenType { get; set; }

		[JsonPropertyName("not-before-policy")]
		public int NotBeforePolicy { get; set; }

		[JsonPropertyName("scope")]
		public string Scope { get; set; }


	}
}
