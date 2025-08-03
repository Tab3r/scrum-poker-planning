using System;
using AutoMapper;
using PokerPlanningBackend.Domain.Entities;
using PokerPlanningBackend.Domain.Repositories;

namespace PokerPlanningBackend.Application.Services;

public class CardService : IService, ICardService
{
    private readonly ICardRepository cardRepository;

    public CardService(ICardRepository cardRepository)
    {
        this.cardRepository = cardRepository;
    }

    public async Task<Card> CreateNewCard(int value)
    {
        var cardCreated = await cardRepository.CreateNewCard(value);
        return cardCreated;
    }

    public async Task<List<Card>> GetAllCardsAsync()
    {
        var cards = await cardRepository.GetAllCards();
        return cards;
    }
}

