using Tree.Domain.ModelInterfaces;

namespace Tree.Repository.BusinessModels
{
    internal class TreeType : ITreeType
    {
        /// <summary>
        /// Gets or inernal sets id of tree type.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or inernal sets name of tree type.
        /// </summary>
        public string Name { get; internal set; }
    }
}
