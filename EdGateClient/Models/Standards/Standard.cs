using AndcultureCode.EdGateClient.Models;
using AndcultureCode.EdGateClient.Models.Metadata;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EdGateClient.Models.Standards
{
    public class Standard : BaseObject
    {
        /// <summary>
        /// ID of the standards set the standard belongs to
        /// EdGate Property: set
        /// </summary>
        [JsonProperty("set")]
        public string Set { get; set; }

        /// <summary>
        /// The numbering designation provided by the standards issuing authority
        /// EdGate Property: standard_number
        /// </summary>
        [JsonProperty("standard_number")]
        public string StandardNumber { get; set; }

        /// <summary>
        /// The text of the standard
        /// EdGate Property: standard_text
        /// </summary>
        [JsonProperty("standard_text")]
        public string StandardText { get; set; }

        /// <summary>
        /// The leveling nomenclature for the standard
        /// EdGate Property: label
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// The level depth of the standard	
        /// EdGate Property: depth
        /// </summary>
        [JsonProperty("depth")]
        public int Depth { get; set; }

        /// <summary>
        /// The general subject areas of the standard
        /// EdGate Property: subject
        /// </summary>
        [JsonProperty("subject")]
        public List<string> Subject { get; set; }

        /// <summary>
        /// The grade levels of the standard
        /// EdGate Property: grade
        /// </summary>
        [JsonProperty("grade")]
        public List<string> Grade { get; set; }

        /// <summary>
        /// The year (and possibly month) the standard was adopted
        /// EdGate Property: adopted
        /// </summary>
        [JsonProperty("adopted")]
        public string Adopted { get; set; }

        /// <summary>
        /// Timestamp of when the standard record was last modified in the EdGate repository
        /// EdGate Property: modified
        /// </summary>
        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        /// <summary>
        /// GUID of parent standard
        /// EdGate Property: parent
        /// </summary>
        [JsonProperty("parent")]
        public Guid Parent { get; set; }

        /// <summary>
        /// List of GUIDs of child standards
        /// EdGate Property: children
        /// </summary>
        [JsonProperty("children")]
        public List<string> Children { get; set; }

        /// <summary>
        /// Additional data about the standard
        /// EdGate Property: metadata
        /// </summary>
        [JsonProperty("metadata")]
        public List<Metadata> Metadata { get; set; }

        /// <summary>
        /// Additional data about the standard
        /// EdGate Property: correlated
        /// </summary>
        [JsonProperty("correlated")]
        public bool Correlated { get; set; }

    }
}
