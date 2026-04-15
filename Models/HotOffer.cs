namespace hakaton_yz_api.Models
{
    public class HotOffer
    {
        public Guid OfferId { get; set; } = Guid.NewGuid();
        public Guid WagonId { get; set; }
        public string OfferCity { get; set; } = string.Empty; 
        public double DiscountPercentage { get; set; } 
        public double SavedEmptyKm { get; set; } 
    }
}
