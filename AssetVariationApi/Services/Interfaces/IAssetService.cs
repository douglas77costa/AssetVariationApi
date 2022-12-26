using System.Collections.Generic;
using System.Threading.Tasks;
using AssetVariationApi.Models.Response;

namespace AssetVariationApi.Services.Interfaces;

public interface IAssetService
{
    Task<List<GetAssetResponse>> GetAssetVariation();
}