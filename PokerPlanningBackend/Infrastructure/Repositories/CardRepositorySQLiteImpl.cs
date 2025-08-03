using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokerPlanningBackend.Domain.Entities;
using PokerPlanningBackend.Domain.Repositories;
using PokerPlanningBackend.Infrastructure.EntityFramework;
using PokerPlanningBackend.Infrastructure.EntityFramework.Entities;

namespace PokerPlanningBackend.Infrastructure.Repositories;

public class CardRepositorySQLiteImpl : ICardRepository
{
    private readonly PokerPlanningSQLiteContext _context;
    private readonly IMapper _mapper;

    public CardRepositorySQLiteImpl(PokerPlanningSQLiteContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper;
    }

    public async Task<Card> CreateNewCard(int value)
    {
        var newCard = new CardDAO()
        {
            Id = Guid.NewGuid(),
            Value = value
        };

        var cardCreated = await _context.Cards.AddAsync(newCard);

        await _context.SaveChangesAsync();

        var retValue = this._mapper.Map<Card>(cardCreated.Entity);

        return retValue;
    }

    public async Task<List<Card>> GetAllCards()
    {
        var cardsDb = await _context.Cards.ToListAsync();
        return this._mapper.Map<List<Card>>(cardsDb);
    }
}
