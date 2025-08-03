using System;
using PokerPlanningBackend.Domain.Entities;

namespace PokerPlanningBackend.Domain.Repositories;

public interface ICardRepository
{
    Task<List<Card>> GetAllCards();
    Task<Card> CreateNewCard(int value);
}
