using System;
using PokerPlanningBackend.Domain.Entities;

namespace PokerPlanningBackend.Application.Services;

public interface ICardService
{
    Task<Card> CreateNewCard(int value);
    Task<List<Card>> GetAllCardsAsync();
}
