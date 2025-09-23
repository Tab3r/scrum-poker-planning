using System;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PokerPlanningBackend.Domain.Entities;
using PokerPlanningBackend.Infrastructure.EntityFramework;

namespace PokerPlanningBackend.Tests.Integration.Infrastructure.Controllers;

public class CardControllerTest : IClassFixture<IntegrationTestWebApplicationFactory>
{

    private readonly HttpClient _httpClient;
    private readonly PokerPlanningSQLiteContext _dbContext;

    public CardControllerTest(IntegrationTestWebApplicationFactory factory)
    {
        _httpClient = factory.CreateClient();
        var scope = factory.Services.CreateScope();
        _dbContext = scope.ServiceProvider.GetRequiredService<PokerPlanningSQLiteContext>();
    }

    [Fact(DisplayName = "[Happy path] Add card")]
    public async Task Create_CreateCard_WhenDataIsOK()
    {
        // Arrange
        int value = 3;
        // Act
        var response = await _httpClient.PostAsJsonAsync("api/card", value);
        // Assert
        var responseJson = await response.Content.ReadAsStringAsync();
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
    }

    [Fact(DisplayName = "[Happy path] Add card and retrieve")]
    public async Task Create_and_retrieve_card()
    {
        // Arrange
        int value = 3;
        var responseCreate = await _httpClient.PostAsJsonAsync("api/card", value);
        var responseCreateJson = await responseCreate.Content.ReadAsStringAsync();
        // Act
        var response = await _httpClient.GetAsync("/api/Card");
        // Assert
        var responseJson = await response.Content.ReadAsStringAsync();
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

}
