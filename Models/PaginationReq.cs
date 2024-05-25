using System.ComponentModel.DataAnnotations;

namespace Models;

public class PaginationReq
{
    public int PageNo { get; set; } = 1;

    public int PerPage { get; set; } = 10;
}