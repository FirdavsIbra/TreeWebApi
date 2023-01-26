using Tree.Domain.ModelInterfaces;

namespace Tree.Service.DTOs
{
    public sealed class TreeTypeDto : ITreeType
    {
        /// <summary>
        /// Gets or sets id of tree type.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets name of tree type.
        /// </summary>
        public string Name { get; set; }
    }
}
