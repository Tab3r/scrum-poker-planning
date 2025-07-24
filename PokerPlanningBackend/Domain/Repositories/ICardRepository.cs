using System;
using PokerPlanningBackend.Domain.Entities;

namespace PokerPlanningBackend.Domain.Repositories;

public interface ICardRepository
{
    List<Card> GetAllCards();
}
