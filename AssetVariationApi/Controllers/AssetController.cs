using System.Collections.Generic;
using System.Threading.Tasks;
using AssetVariationApi.Models.Response;
using AssetVariationApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetVariationApi.Controllers;

/// <summary>
/// Assets Controller
/// </summary>
[Route("api/v1/asset")]
[ApiController]
public class AssetController : Controller
{
    private readonly IAssetService _assetService;

    public AssetController(IAssetService assetService)
    {
        _assetService = assetService;
    }

    /// <summary>
    /// Get BTC assets
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<GetAssetResponse>))]
    [ProducesResponseType(400, Type = typeof(ValidationBadRequestResponse))]
    [ProducesResponseType(500, Type = typeof(RequestResponse))]
    public async Task<IActionResult> GetAsync()
    {
        var response = await _assetService.GetAssetVariation();
        return Ok(response);
    }
}