namespace AndcultureCode.EdGateClient.Interfaces
{
    public interface IEdGateClient
    {
        /// <summary>
        /// Profile Client
        /// </summary>
        IEdGateProfileClient Profile { get; }

        /// <summary>
        /// Standards Client
        /// </summary>
        IEdGateStandardsClient Standards { get; }
    }
}
