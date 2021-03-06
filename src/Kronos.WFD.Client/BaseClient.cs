﻿using Kronos.WFD.Authentication;
using Kronos.WFD.Client.Requests;
using System;
using System.Net.Http;

namespace Kronos.WFD.Client
{
    public enum ApiVersion
    {
        v1
    }

    public class BaseClient : IBaseClient
    {
        private string baseUrl;

        /// <summary>
        /// Constructs a new <see cref="BaseClient"/>.
        /// </summary>
        /// <param name="tenantName">The base service URL. For example, "https://graph.microsoft.com/v1.0."</param>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> for authenticating request messages.</param>
        /// <param name="httpProvider">The <see cref="IHttpProvider"/> for sending requests.</param>
        public BaseClient(
            string tenantName,
            IAuthenticationProvider authenticationProvider,
            ApiVersion apiVersion = ApiVersion.v1,
            IHttpProvider httpProvider = null)
        {
            this.BaseUrl = "https://" + tenantName + ".mykronos.com/api";
            switch (apiVersion)
            {
                default:
                    this.BaseUrl += "/v1";
                    break;
            }
            this.AuthenticationProvider = authenticationProvider;
            this.HttpProvider = httpProvider ?? new HttpProvider(tenantName, new Serializer());
        }

        /// <summary>
        /// Constructs a new <see cref="BaseClient"/>.
        /// </summary>
        /// <param name="tenantName">The base service URL. For example, "https://graph.microsoft.com/v1.0."</param>
        /// <param name="httpClient">The custom <see cref="HttpClient"/> to be used for making requests</param>
        public BaseClient(
            string tenantName,
            HttpClient httpClient,
            ApiVersion apiVersion = ApiVersion.v1)
        {
            this.BaseUrl = "https://" + tenantName + ".mykronos.com/api";
            switch (apiVersion)
            {
                default:
                    this.BaseUrl += "/v1";
                    break;
            }
            this.HttpProvider = new SimpleHttpProvider(httpClient);
        }

        /// <summary>
        /// Gets the <see cref="IAuthenticationProvider"/> for authenticating requests.
        /// </summary>
        public IAuthenticationProvider AuthenticationProvider { get; set; }

        /// <summary>
        /// Gets or sets the base URL for requests of the client.
        /// </summary>
        public string BaseUrl
        {
            get { return this.baseUrl; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ServiceException(
                        new Error
                        {
                            Code = ErrorConstants.Codes.InvalidRequest,
                            Message = ErrorConstants.Messages.BaseUrlMissing,
                        });
                }

                this.baseUrl = value.TrimEnd('/');
            }
        }

        /// <summary>
        /// Gets the <see cref="IHttpProvider"/> for sending HTTP requests.
        /// </summary>
        public IHttpProvider HttpProvider { get; private set; }

        /// <summary>
        /// Gets or Sets the <see cref="IAuthenticationProvider"/> for authenticating a single HTTP requests. 
        /// </summary>
        public Func<IAuthenticationProvider> PerRequestAuthProvider { get; set; }
    }

    public interface IBaseClient
    {
        /// <summary>
        /// Gets the <see cref="IAuthenticationProvider"/> for authenticating HTTP requests.
        /// </summary>
        IAuthenticationProvider AuthenticationProvider { get; }

        /// <summary>
        /// Gets the base URL for requests of the client.
        /// </summary>
        string BaseUrl { get; }

        /// <summary>
        /// Gets the <see cref="IHttpProvider"/> for sending HTTP requests.
        /// </summary>
        IHttpProvider HttpProvider { get; }

        /// <summary>
        /// Gets or Sets the <see cref="IAuthenticationProvider"/> for authenticating a single HTTP requests. 
        /// </summary>
        Func<IAuthenticationProvider> PerRequestAuthProvider { get; set; }
    }
}
