namespace Journaley.Controls
{
    /// <summary>
    /// Interface for selectable controls.
    /// </summary>
    internal interface ISelectable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ISelectable"/> is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        bool Selected { get; set; }
    }
}
