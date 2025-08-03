using System;
using System.ComponentModel.DataAnnotations;

namespace PokerPlanningBackend.Infrastructure.EntityFramework.Entities;

public class CardDAO
{
    [Key]
    public Guid Id { get; set; }
    public int Value { get; set; }
}
