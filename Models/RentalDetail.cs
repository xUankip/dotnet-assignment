namespace Dotnet_Assignment.Models;

public class RentalDetail
{
    public int RentalDetailID { get; set; }
    public int RentalID { get; set; }
    public int ComicBookID { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerDay { get; set; }

    public virtual Rental Rental { get; set; }
    public virtual ComicBook ComicBook { get; set; }
}
