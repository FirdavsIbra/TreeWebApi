namespace Tree.Domain.ModelInterfaces
{
    public interface ITreeType
    {
        /// <summary>
        /// Gets or sets id of type.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets or sets name of type of tree.
        /// </summary>
        public string Name { get; }
    }
}