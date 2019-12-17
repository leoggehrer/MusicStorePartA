//@BaseCode
//MdStart
namespace MusicStore.Contracts
{
    /// <summary>
    /// Defines the basic properties and methods of identifiable components.
    /// </summary>
    public partial interface IIdentifiable
    {
        /// <summary>
        /// Gets the identity of the component.
        /// </summary>
        int Id { get; }
    }
}
//MdEnd
