using Newtonsoft.Json;

namespace AndcultureCode.EdGateClient.Models.Metadata
{
    public class Metadata
    {
        /// <summary>
        /// Name of data field
        /// EdGate Property: name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Value of data field
        /// EdGate Property: value
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
