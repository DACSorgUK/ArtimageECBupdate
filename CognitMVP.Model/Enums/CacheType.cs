namespace DacsOnline.Model.Enums
{
    /// <summary>
    /// Cache Type
    /// </summary>
    public enum CacheType
    {
        /// <summary>
        /// Sliding expiry ?
        /// </summary>
        SLIDING,

        /// <summary>
        /// Absolute expiry ?
        /// </summary>
        ABSOLUTE,

        /// <summary>
        /// Dependancy expiry ?
        /// </summary>
        DEPENDENCY
    }
}