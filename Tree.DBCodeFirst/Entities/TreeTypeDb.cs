namespace Tree.DBCodeFirst.Entities
{
    public class TreeTypeDb
    {
        /// <summary>
        /// Gets or sets id of type.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets name of type of tree.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets sorts of tree.
        /// </summary>
        public virtual ICollection<TreeSortDb> TreeSorts { get; set; }
    }
}
