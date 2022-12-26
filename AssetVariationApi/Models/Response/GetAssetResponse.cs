using System;

namespace AssetVariationApi.Models.Response;

public class GetAssetResponse
{
    public int Day { get; set; }
    public DateTime Date { get; set; }
    public Double Value { get; set; }
    public Double? LastVariation { get; set; }
    public Double? FirstVariation { get; set; }
}