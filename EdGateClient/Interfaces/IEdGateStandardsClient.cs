using AndcultureCode.EdGateClient.Models.Standards;
using EdGateClient.Models.Standards;
using System.Collections.Generic;

namespace AndcultureCode.EdGateClient.Interfaces
{
    public interface IEdGateStandardsClient
    {
        /// <summary>
        /// Export a full list of standard objects for a given standards set
        /// </summary>
        /// <param name="standardsSetId">Abbreviation of standards set</param>
        /// <param name="subject">Subject area of standards set</param>
        /// <returns></returns>
        List<Standard> ExportStandards(string standardsSetId, string subject = "");

        /// <summary>
        /// Get the list of standards set objects
        /// </summary>
        /// <returns></returns>
        List<StandardsSet> GetStandardsSets();

        /// <summary>
        /// Get list of standards for a given standards set
        /// </summary>
        /// <param name="standardsSetId">Filter standards down to this standards set</param>
        /// <param name="subject">Subject area of standards</param>
        /// <param name="grade">Grade level of standards</param>
        /// <param name="correlate">Flag to show correlation status of the standards in response</param>
        /// <returns></returns>
        List<Standard> GetStandardsBySet(string standardsSetId, string subject, string grade, bool correlate);

        /// <summary>
        /// Get data for an individual standard
        /// </summary>
        /// <param name="standardId">Id of the standard to retrieve</param>
        /// <returns></returns>
        Standard GetStandard(string standardId);

    }
}
