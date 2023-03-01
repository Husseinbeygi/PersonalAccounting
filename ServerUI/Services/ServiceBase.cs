﻿using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Web;

namespace ServerUI.Services;


public abstract class ServiceBase : object
{
	public ServiceBase(HttpClient http,
		AuthenticationStateProvider authenticationStateProvider)
	{
		Http = http;
		AuthenticationStateProvider = authenticationStateProvider;
	}

	protected string BaseUrl { get; set; }

	protected HttpClient Http { get; }
	public AuthenticationStateProvider AuthenticationStateProvider { get; }

	public virtual async Task<TResponse> GetAsync<TResponse>(string url, string query = null)
	{
		HttpResponseMessage response = null;

		try
		{
			AddAcceptedLanguageHeader();

			await SetAuthHeaderAsync();

			string requestUri =
				$"{BaseUrl}/{url}";

			if (string.IsNullOrWhiteSpace(query) == false)
			{
				requestUri =
					$"{requestUri}?{query}";
			}

			response =
				await
				Http.GetAsync
				(requestUri: requestUri)
				;


			try
			{
				TResponse result =
					await
					response?.Content?.ReadFromJsonAsync<TResponse>();

				return result;
			}
			catch (NotSupportedException ex)
			{
				string errorMessage =
					$"Exception: {ex.Message} - The content type is not supported.";
			}
			catch (JsonException ex)
			{
				string errorMessage =
					$"Exception: {ex.Message} - Invalid JSON.";

			}
		}
		catch (HttpRequestException ex)
		{
			string errorMessage =
				$"Exception: {ex.Message}";
		}
		finally
		{
			response?.Dispose();
		}

		return default;
	}

	public virtual async Task<TResponse> PostAsync<TData, TResponse>(string url, TData data)
	{
		HttpResponseMessage response = null;


		var options = new JsonSerializerOptions
		{
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
			WriteIndented = true
		};

		if (string.IsNullOrWhiteSpace(url))
		{
			throw new Exception($"Exception:  Url is null.");
		}

		if (data is null)
		{
			throw new Exception($"Exception:  Data is null.");
		}

		try
		{
			//await SetTenantIdAsync(data);

			await SetAuthHeaderAsync();

			AddAcceptedLanguageHeader();

			AddIdempotencyHeader();

			string requestUri =
				$"{BaseUrl}/{url}";

			response =
				await
				Http.PostAsJsonAsync(requestUri, data, options);

			try
			{
				TResponse result =
					await
					response?.Content?.ReadFromJsonAsync<TResponse>();

				return result;
			}
			catch (NotSupportedException ex)
			{
				string errorMessage =
					$"Exception: {ex.Message} - The content type is not supported.";
			}
			catch (JsonException ex)
			{
				string errorMessage =
					$"Exception: {ex.Message} - Invalid JSON.";

			}

		}
		catch (HttpRequestException ex)
		{
			string errorMessage =
				$"Exception: {ex.Message}";
		}
		finally
		{
			response?.Dispose();
		}
		return default;
	}

	public virtual async Task<TResponse> PatchAsync<TData, TResponse>(string url, TData data)
	{
		HttpResponseMessage response = null;


		var options = new JsonSerializerOptions
		{
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
			WriteIndented = true
		};

		if (string.IsNullOrWhiteSpace(url))
		{
			throw new Exception($"Exception:  Url is null.");
		}

		if (data is null)
		{
			throw new Exception($"Exception:  Data is null.");
		}

		try
		{
			await SetAuthHeaderAsync();

			AddAcceptedLanguageHeader();

			AddIdempotencyHeader();

			string requestUri =
				$"{BaseUrl}/{url}";

			response =
				await
				Http.PatchAsJsonAsync(requestUri, data, options);
			try
			{
				TResponse result =
					await
					response?.Content?.ReadFromJsonAsync<TResponse>();

				return result;
			}
			catch (NotSupportedException ex)
			{
				string errorMessage =
					$"Exception: {ex.Message} - The content type is not supported.";
			}
			catch (JsonException ex)
			{
				string errorMessage =
					$"Exception: {ex.Message} - Invalid JSON.";

			}

		}
		catch (HttpRequestException ex)
		{
			string errorMessage =
				$"Exception: {ex.Message}";
		}
		finally
		{
			response?.Dispose();
		}
		return default;
	}

	public virtual async Task<TResponse> DeleteAsync<TKey, TResponse>(string url, IEnumerable<TKey> keys)
	{
		HttpResponseMessage response = null;

		if (string.IsNullOrWhiteSpace(url))
		{
			throw new Exception($"Exception:  Url is null.");
		}

		if (keys is null)
		{
			throw new Exception($"Exception:  Data is null.");
		}

		try
		{

			await SetAuthHeaderAsync();

			AddAcceptedLanguageHeader();

			AddIdempotencyHeader();

			string requestUri =
				$"{BaseUrl}/{url}";

			var queryString = HttpUtility.ParseQueryString(string.Empty);
			foreach (var id in keys)
			{
				queryString.Add("ids", id.ToString());
			}

			Console.WriteLine(queryString);
			response =
				await
				Http.DeleteAsync(string.Concat(requestUri, "?", queryString));

			try
			{
				TResponse result =
					await
					response?.Content?.ReadFromJsonAsync<TResponse>();

				return result;
			}
			catch (NotSupportedException ex)
			{
				string errorMessage =
					$"Exception: {ex.Message} - The content type is not supported.";
			}
			catch (JsonException ex)
			{
				string errorMessage =
					$"Exception: {ex.Message} - Invalid JSON.";

			}
		}
		catch (HttpRequestException ex)
		{
			string errorMessage =
				$"Exception: {ex.Message}";
		}
		finally
		{
			response?.Dispose();
		}
		return default;
	}

	private async Task SetAuthHeaderAsync()
	{
		//var readToken = await _tokenProvider.ReadIdToken();
		//Http.DefaultRequestHeaders.Authorization =
		//	new AuthenticationHeaderValue("Bearer", readToken);
	}

	private async Task SetTenantIdAsync<TData>(TData? data)
	{
		var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

		if (data is null) { return; }

		var _tenantId = data.GetType().GetProperty("TenantId");

		if (_tenantId == null) { return; }
		_tenantId.SetValue(data, Guid.Parse(authState.User.Claims.FirstOrDefault(x => x.Type == "OrganizationId").Value));


		var _ownerId = data.GetType().GetProperty("OwnerId");
		if (_ownerId == null) { return; }
		_ownerId.SetValue(data, Guid.Parse(authState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value));

		var _createdById = data.GetType().GetProperty("CreatedById");
		if (_createdById == null) { return; }
		_createdById.SetValue(data, Guid.Parse(authState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value));


		var _modifiedById = data.GetType().GetProperty("ModifiedById");
		if (_modifiedById == null) { return; }
		_modifiedById.SetValue(data, Guid.Parse(authState.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value));


	}

	private void AddIdempotencyHeader()
	{

		if (!Http.DefaultRequestHeaders.Any(x => x.Key == "Idempotency-Key"))
		{
			var key = Guid.NewGuid();
			Http.DefaultRequestHeaders.Remove("Idempotency-Key");
			Http.DefaultRequestHeaders.Add("Idempotency-Key",
				key.ToString());

		}
	}

	private void AddAcceptedLanguageHeader()
	{
		var LanguageHeader = Http.DefaultRequestHeaders.AcceptLanguage;
		if (!LanguageHeader.Any(x => x.Value == Thread.CurrentThread.CurrentUICulture.Name))
		{
			Http.DefaultRequestHeaders.Remove("Accept-Language");
			Http.DefaultRequestHeaders.Add("Accept-Language",
				Thread.CurrentThread.CurrentUICulture.Name);

		}
	}
}
