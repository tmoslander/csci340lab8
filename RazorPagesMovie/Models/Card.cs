using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models;

public class Card
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    [Display(Name = "Pokemon Type")]
    public string? PokemonType { get; set; }

    [Display(Name = "Expansion Set")]
    public string ? ExpansionSet {get; set; }
    public decimal Price { get; set; }
}