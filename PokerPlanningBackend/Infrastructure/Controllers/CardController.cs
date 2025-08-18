using System;
using Microsoft.AspNetCore.Mvc;
using PokerPlanningBackend.Application.Services;
using PokerPlanningBackend.Domain.Entities;

namespace PokerPlanningBackend.Infrastructure.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpPost]
    public async Task<ActionResult<Card>> CreateNewCard([FromBody] int value)
    {
        var cardCreated = await this._cardService.CreateNewCard(value);
        return Created(string.Empty, cardCreated);
    }
}
