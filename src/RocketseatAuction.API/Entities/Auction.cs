namespace RocketseatAuction.API.Entities;

public class Auction
{
    public int Id { get; set; } // get pode obter o valor e set permite edição
    public string Name { get; set; } = string.Empty;
    public DateTime Starts { get; set; }
    public DateTime Ends { get; set; }

    public List<Item> Items { get; set; } = [];
}