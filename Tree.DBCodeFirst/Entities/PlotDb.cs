﻿namespace Tree.DBCodeFirst.Entities
{
    public sealed class PlotDb
    {
        /// <summary>
        /// Gets or sets id of plot.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets capacity of plot.
        /// </summary>
        public double Capacity { get; set; }

        /// <summary>
        /// Gets or sets trees.
        /// </summary>
        public ICollection<TreeDb> Trees { get; set; }
    }
}
