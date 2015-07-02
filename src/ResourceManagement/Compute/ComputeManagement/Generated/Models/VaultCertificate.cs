namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class VaultCertificate
    {
        /// <summary>
        /// Gets or sets the URL referencing a secret in a Key Vault which
        /// contains a properly formatted certificate.
        /// </summary>
        [JsonProperty(PropertyName = "certificateUrl")]
        public string CertificateUrl { get; set; }

        /// <summary>
        /// Gets or sets the Certificate store in LocalMachine to add the
        /// certificate to on Windows, leave empty on Linux.
        /// </summary>
        [JsonProperty(PropertyName = "certificateStore")]
        public string CertificateStore { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
