namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using Microsoft.Azure;
    using Models;

    internal partial class VirtualMachineExtensionImagesOperations : IServiceOperations<ComputeManagementClient>, IVirtualMachineExtensionImagesOperations
    {
        /// <summary>
        /// Initializes a new instance of the VirtualMachineExtensionImagesOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal VirtualMachineExtensionImagesOperations(ComputeManagementClient client)
        {
            this.Client = client;
        }

        /// <summary>
        /// Gets a reference to the ComputeManagementClient
        /// </summary>
        public ComputeManagementClient Client { get; private set; }

        /// <summary>
        /// Gets a virtual machine extension image.
        /// </summary>
        /// <param name='location'>
        /// </param>    
        /// <param name='publisherName'>
        /// </param>    
        /// <param name='type'>
        /// </param>    
        /// <param name='version'>
        /// </param>    
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<VirtualMachineExtensionImage>> GetWithOperationResponseAsync(string location, string publisherName, string type, string version, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (location == null)
            {
                throw new ArgumentNullException("location");
            }
            if (publisherName == null)
            {
                throw new ArgumentNullException("publisherName");
            }
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (version == null)
            {
                throw new ArgumentNullException("version");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("location", location);
                tracingParameters.Add("publisherName", publisherName);
                tracingParameters.Add("type", type);
                tracingParameters.Add("version", version);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "Get", tracingParameters);
            }
            // Construct URL
            string url = this.Client.BaseUri.AbsoluteUri + 
                         "//subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}";
            if (this.Client.Credentials == null)
            {
                throw new ArgumentNullException("Credentials", "SubscriptionCloudCredentials are missing from the client.");
            }
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(this.Client.Credentials.SubscriptionId));
            url = url.Replace("{location}", Uri.EscapeDataString(location));
            url = url.Replace("{publisherName}", Uri.EscapeDataString(publisherName));
            url = url.Replace("{type}", Uri.EscapeDataString(type));
            url = url.Replace("{version}", Uri.EscapeDataString(version));
            List<string> queryParameters = new List<string>();
            queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.Client.ApiVersion)));
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // trim all duplicate forward slashes in the url
            url = Regex.Replace(url, "([^:]/)/+", "$1");
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            // Set Credentials
            cancellationToken.ThrowIfCancellationRequested();
            await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                CloudError errorBody = JsonConvert.DeserializeObject<CloudError>(responseContent, this.Client.DeserializationSettings);
                if (errorBody != null)
                {
                    ex = new CloudException(errorBody.Message);
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new AzureOperationResponse<VirtualMachineExtensionImage>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                result.Body = JsonConvert.DeserializeObject<VirtualMachineExtensionImage>(responseContent, this.Client.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Gets a list of virtual machine extension image versions.
        /// </summary>
        /// <param name='location'>
        /// </param>    
        /// <param name='publisherName'>
        /// </param>    
        /// <param name='type'>
        /// </param>    
        /// <param name='parametersFilterExpressionunencoded'>
        /// </param>    
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<VirtualMachineImageResourceList>> ListVersionsWithOperationResponseAsync(string location, string publisherName, string type, string parametersFilterExpressionunencoded = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            if (location == null)
            {
                throw new ArgumentNullException("location");
            }
            if (publisherName == null)
            {
                throw new ArgumentNullException("publisherName");
            }
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("location", location);
                tracingParameters.Add("publisherName", publisherName);
                tracingParameters.Add("type", type);
                tracingParameters.Add("parametersFilterExpressionunencoded", parametersFilterExpressionunencoded);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "ListVersions", tracingParameters);
            }
            // Construct URL
            string url = this.Client.BaseUri.AbsoluteUri + 
                         "//subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions";
            if (this.Client.Credentials == null)
            {
                throw new ArgumentNullException("Credentials", "SubscriptionCloudCredentials are missing from the client.");
            }
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(this.Client.Credentials.SubscriptionId));
            url = url.Replace("{location}", Uri.EscapeDataString(location));
            url = url.Replace("{publisherName}", Uri.EscapeDataString(publisherName));
            url = url.Replace("{type}", Uri.EscapeDataString(type));
            List<string> queryParameters = new List<string>();
            if (parametersFilterExpressionunencoded != null)
            {
                queryParameters.Add(string.Format("{parameters.FilterExpression:unencoded}={0}", parametersFilterExpressionunencoded));
            }
            queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.Client.ApiVersion)));
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // trim all duplicate forward slashes in the url
            url = Regex.Replace(url, "([^:]/)/+", "$1");
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            // Set Credentials
            cancellationToken.ThrowIfCancellationRequested();
            await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                CloudError errorBody = JsonConvert.DeserializeObject<CloudError>(responseContent, this.Client.DeserializationSettings);
                if (errorBody != null)
                {
                    ex = new CloudException(errorBody.Message);
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new AzureOperationResponse<VirtualMachineImageResourceList>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                result.Body = JsonConvert.DeserializeObject<VirtualMachineImageResourceList>(responseContent, this.Client.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Gets a list of virtual machine extension image types.
        /// </summary>
        /// <param name='location'>
        /// </param>    
        /// <param name='publisherName'>
        /// </param>    
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<VirtualMachineImageResourceList>> ListTypesWithOperationResponseAsync(string location, string publisherName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (location == null)
            {
                throw new ArgumentNullException("location");
            }
            if (publisherName == null)
            {
                throw new ArgumentNullException("publisherName");
            }
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("location", location);
                tracingParameters.Add("publisherName", publisherName);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(invocationId, this, "ListTypes", tracingParameters);
            }
            // Construct URL
            string url = this.Client.BaseUri.AbsoluteUri + 
                         "//subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types";
            if (this.Client.Credentials == null)
            {
                throw new ArgumentNullException("Credentials", "SubscriptionCloudCredentials are missing from the client.");
            }
            url = url.Replace("{subscriptionId}", Uri.EscapeDataString(this.Client.Credentials.SubscriptionId));
            url = url.Replace("{location}", Uri.EscapeDataString(location));
            url = url.Replace("{publisherName}", Uri.EscapeDataString(publisherName));
            List<string> queryParameters = new List<string>();
            queryParameters.Add(string.Format("api-version={0}", Uri.EscapeDataString(this.Client.ApiVersion)));
            if (queryParameters.Count > 0)
            {
                url += "?" + string.Join("&", queryParameters);
            }
            // trim all duplicate forward slashes in the url
            url = Regex.Replace(url, "([^:]/)/+", "$1");
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);
            // Set Headers
            // Set Credentials
            cancellationToken.ThrowIfCancellationRequested();
            await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!(statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK")))
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", statusCode));
                CloudError errorBody = JsonConvert.DeserializeObject<CloudError>(responseContent, this.Client.DeserializationSettings);
                if (errorBody != null)
                {
                    ex = new CloudException(errorBody.Message);
                    ex.Body = errorBody;
                }
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            // Create Result
            var result = new AzureOperationResponse<VirtualMachineImageResourceList>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            // Deserialize Response
            if (statusCode == (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), "OK"))
            {
                result.Body = JsonConvert.DeserializeObject<VirtualMachineImageResourceList>(responseContent, this.Client.DeserializationSettings);
            }
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

    }
}
