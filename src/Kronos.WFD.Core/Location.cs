﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Kronos.WFD
{
    public enum LocationContext
    {
        [Description("ORG")]
        [EnumMember(Value = "ORG")]
        Organization,

        [Description("FORECAST")]
        [EnumMember(Value = "FORECAST")]
        Forecast
    }

    public enum LocationQualifier
    {

    }

    public class LocationReference
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "qualifier", NullValueHandling = NullValueHandling.Ignore)]
        public LocationQualifier? Qualifier { get; set; }

        public LocationReference() { }

        public LocationReference(string id)
        {
            Id = id;
        }

        public LocationReference(LocationQualifier qualifier)
        {
            Qualifier = qualifier;
        }
    }

    public class Location
    {
        [JsonProperty(PropertyName = "persistentId")]
        public string PersistentId { get; set; }

        [JsonProperty(PropertyName = "nodeId")]
        public string NodeId { get; set; }

        [JsonProperty(PropertyName = "externalId")]
        public string ExternalId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "effectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [JsonProperty(PropertyName = "expirationDate")]
        public DateTime ExpirationDate { get; set; }

        [JsonProperty(PropertyName = "firstRevision")]
        public bool FirstRevision { get; set; }

        [JsonProperty(PropertyName = "lastRevision")]
        public bool LastRevision { get; set; }

        [JsonProperty(PropertyName = "directWorkPercent")]
        public int DirectWorkPercent { get; set; }

        [JsonProperty(PropertyName = "indirectWorkPercent")]
        public int IndirectWorkPercent { get; set; }

        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
