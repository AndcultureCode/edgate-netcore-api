using Newtonsoft.Json;

namespace AndcultureCode.EdGateClient.Models.Standards
{
    public class StandardsSet
    {
        /// <summary>
        /// An identifier for the standards set
        /// EdGate Property: set_id
        /// </summary>
        [JsonProperty("set_id")]
        public string SetId { get; set; }

        /// <summary>
        /// Name of the standards set
        /// EdGate Property: name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Name of the parent group the standards set belongs to
        /// EdGate Property: parent
        /// </summary>
        [JsonProperty("parent")]
        public string Parent { get; set; }
    }
}
