namespace Epic.Domain.Interfaces
{
	public interface IShippingCalculator
	{
		decimal GetShippingPrice(Address address);
	}
}