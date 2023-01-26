namespace Tree.DatabaseFirst.Models;

public partial class Tree
{
    public long Id { get; set; }

    public int Sort { get; set; }

    public int Type { get; set; }

    public double HeightInMetre { get; set; }

    public double Square { get; set; }

    public double BeginingOfTheHarvestInY { get; set; }

    public long Count { get; set; }

    public long PlotId { get; set; }

    public virtual Plot Plot { get; set; } = null!;
}
