using System.Collections.Generic;

namespace AssetVariationApi.Models.Response
{
    /// <summary>
    ///  Base response from all api requests
    /// </summary>
    public class RequestResponse
    {
        /// <summary>
        /// Informative message from request processing
        /// </summary>
        public string Message { get; set; }
        public string Info { get; set; }
        public string Source { get; set; }
    }

    public class ValidationBadRequestResponse : RequestResponse
    {
        /// <summary>
        /// Model validation error list
        /// </summary>
        public List<ErrorResponse> Errors { get; set; }

    }

    /// <summary>
    /// Base response from all api requests
    /// </summary>
    public class RequestResponse<TEntity> : RequestResponse
    {
        /// <summary>
        /// Data result from request processing
        /// </summary>
        public TEntity Response { get; set; }
    }

    /// <summary>
    /// Base response from all api requests
    /// </summary>
    public class ModelValidationResponse : RequestResponse
    {
        /// <summary>
        /// Data result from request processing
        /// </summary>
        public IEnumerable<ErrorResponse> ModelErrors { get; set; }

        /// <summary>
        /// Custom errorcode
        /// </summary>
        public int? ErrorCode { get; set; }
    }
}
