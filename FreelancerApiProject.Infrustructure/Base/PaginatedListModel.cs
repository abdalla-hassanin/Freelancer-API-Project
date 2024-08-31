namespace FreelancerApiProject.Infrustructure.Base;

public class PaginatedListModel<T>
{
    public IEnumerable<T>? Items { get; set; }

    public int TotalItems { get; set; }

    public int TotalPages { get; set; }

    public int CurrentPage { get; set; }
}