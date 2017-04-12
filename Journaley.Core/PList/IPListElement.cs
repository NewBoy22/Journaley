namespace Journaley.Core.PList
{
    using System.Xml;

    /// <summary>
    /// PList data interface
    /// </summary>
    public interface IPListElement
    {
        /// <summary>
        /// Saves this PList data to XML.
        /// </summary>
        /// <param name="parent">The parent.</param>
        void SaveToXml(XmlNode parent);
    }
}
