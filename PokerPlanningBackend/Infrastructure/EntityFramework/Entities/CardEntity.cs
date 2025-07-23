using System;

namespace PokerPlanningBackend.Infrastructure.EntityFramework.Entities;

public class CardEntity
{
    public Guid Id { get; set; }
    public int Value { get; set; }
}
