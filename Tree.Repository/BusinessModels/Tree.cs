﻿using Tree.Domain.ModelInterfaces.Base;

namespace Tree.Repository.BusinessModels
{
    internal sealed class Tree : ITree
    {
        /// <summary>
        /// Gets or sets id of tree.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or sets sort of tree.
        /// </summary>
        public long TreeSortId { get; internal set; }

        /// <summary>
        /// Gets or sets height of tree in metre.
        /// </summary>
        public double HeightInMetre { get; internal set; }

        /// <summary>
        /// Gets or sets ocupying area of the tree.
        /// </summary>
        public double Square { get; internal set; }

        /// <summary>
        /// Gets or sets begining year of the harvest.
        /// </summary>
        public double BeginingOfTheHarvestInY { get; internal set; }

        /// <summary>
        /// Gets or sets plot of tree.
        /// </summary>
        public long PlotId { get; set; }
    }
}
