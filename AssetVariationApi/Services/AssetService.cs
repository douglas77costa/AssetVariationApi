using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AssetVariationApi.Models.Response;
using AssetVariationApi.Services.Interfaces;
using AssetVariationApi.Utils;

namespace AssetVariationApi.Services;

public class AssetService : IAssetService
{
    public async Task<List<GetAssetResponse>> GetAssetVariation()
    {
        try
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://query2.finance.yahoo.com/v8/finance/chart/");

            var responseMessage =
                await client.GetAsync("BTC-USD?range=1mo&interval=1d");

            if (responseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(responseMessage.ToString());
            }

            var successResponseString = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonUtil.JsonDeserialize<AssetsResponse>(successResponseString);

            if (response != null)
            {
                List<GetAssetResponse> variation = new List<GetAssetResponse>();
                List<DateTime> days = new List<DateTime>();

                var timestamps = response?.Chart.Result[0].Timestamp;
                if (timestamps != null)
                {
                    foreach (var time in timestamps)
                    {
                        days.Add(DateTimeOffset.FromUnixTimeSeconds(time).DateTime);
                    }
                }

                for (var index = 0; index < days.Count; index++)
                {
                    if (index != 0)
                    {
                        var dateTime = days[index];
                        double value = 0;
                        if (response!.Chart.Result[0].Indicators.Quote[0].Open[index] != null)
                        {
                            value = Math.Round(response!.Chart.Result[0].Indicators.Quote[0].Open[index] ?? 0, 2);
                        }
                        else
                        {
                            value = variation[index - 2].Value;
                        }

                        var assetResponse = new GetAssetResponse
                        {
                            Day = index,
                            Date = dateTime,
                            Value = value,
                        };


                        if (index == 1)
                        {
                            assetResponse.FirstVariation = null;
                            assetResponse.LastVariation = null;
                        }
                        else
                        {
                            assetResponse.LastVariation =
                                Math.Round(((value / variation[index - 2].Value) - 1) * 100, 2);
                            assetResponse.FirstVariation = Math.Round(((value / variation[0].Value) - 1) * 100, 2);
                        }

                        variation.Add(assetResponse);
                    }
                }

                return variation;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return new List<GetAssetResponse>();
    }
}