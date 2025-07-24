using System;
using PokerPlanningBackend.Domain.Entities;
using PokerPlanningBackend.Infrastructure.EntityFramework;

namespace PokerPlanningBackend.Infrastructure.Repositories;

public class CardRepositorySQLiteImpl
{
    private readonly PokerPlanningSQLiteContext _context;

    public CardRepositorySQLiteImpl(PokerPlanningSQLiteContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<Card> GetAllCards()
    {
        return _context.Cards.Select(card => new Card { Value = card.Value }).ToList();
    }
}
