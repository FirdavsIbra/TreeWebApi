namespace Tree.DatabaseFirst.Models;

public partial class Plot
{
    public long Id { get; set; }

    public double Capacity { get; set; }

    public virtual ICollection<Tree> Trees { get; } = new List<Tree>();
}
