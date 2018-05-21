using AndcultureCode.EdGateClient.Models.Profile;

namespace AndcultureCode.EdGateClient.Interfaces
{
    public interface IEdGateProfileClient
    {
        /// <summary>
        /// Get the profile details for the current account
        /// </summary>
        /// <returns></returns>
        Profile GetProfile();
    }
}
