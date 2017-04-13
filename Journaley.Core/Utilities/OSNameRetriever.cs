namespace Journaley.Core.Utilities
{
    using System.Management;

    /// <summary>
    /// A class containing a convenient method to retrieve a user-friendly name of the running OS.
    /// </summary>
    public static class OSNameRetriever
    {
        /// <summary>
        /// Gets the friendly name of the running OS.
        /// </summary>
        /// <returns>The friendly name of the running OS.</returns>
        public static string GetOSFriendlyName()
        {
            // Code retrieved from: http://stackoverflow.com/a/6331863/922135
            string result = string.Empty;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                "SELECT Caption FROM Win32_OperatingSystem");

            foreach (var o in searcher.Get())
            {
                var os = (ManagementObject) o;
                result = os["Caption"].ToString();
                break;
            }

            if (result.Contains("Windows "))
            {
                result = result.Replace("Windows ", "Windows/");
            }

            return result.Trim();
        }
    }
}
