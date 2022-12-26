using System.Collections.Generic;

namespace AssetVariationApi.Models.Response;

public class ResultResponse
{
    public List<int> Timestamp { get; set; }
    public IndicatorsResponse Indicators { get; set; }
}