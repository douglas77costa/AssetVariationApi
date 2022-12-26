using System.Collections.Generic;

namespace AssetVariationApi.Models.Response;

public class ChartResponse
{
    public List<ResultResponse> Result { get; set; }
    public object Error { get; set; }
}