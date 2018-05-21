using AndcultureCode.EdGateClient.Models.Standards;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AndcultureCode.EdGateClient.Models.Profile
{
    public class Profile
    {
        /// <summary>
        /// A list of standards sets the profile has access to
        /// EdGate Property: standards_sets
        /// </summary>
        [JsonProperty("standards_sets")]
        public List<StandardsSet> StandardsSets { get; set; }

        /// <summary>
        /// A list of subject areas the profile has access to
        /// EdGate Property: subjects
        /// </summary>
        [JsonProperty("subjects")]
        public List<string> Subjects { get; set; }

        /// <summary>
        /// A list of subject areas the profile has access to
        /// EdGate Property: grades
        /// </summary>
        [JsonProperty("grades")]
        public List<string> Grades { get; set; }
    }
}
