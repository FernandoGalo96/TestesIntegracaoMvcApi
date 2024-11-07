using Features.Tests;
using NerdStore.WebApp.MVC;
using NerdStore.WebApp.MVC.Models;
using NerdStore.WebApp.Tests.Config;
using System.Net.Http.Json;

namespace NerdStore.WebApp.Tests.Tests;

[TestCaseOrderer("Features.Tests.PriorityOrderer", "Features.Tests")]
[Collection(nameof(IntegrationApiTestsFixtureCollection))]
public class PedidoApiTests
{
    private readonly IntegrationTestsFixture<Program> _testsFixture;

    public PedidoApiTests(IntegrationTestsFixture<Program> testsFixture)
    {
        _testsFixture = testsFixture;
    }

    [Fact(DisplayName = "Adicionar item em novo pedido"), TestPriority(1)]
    [Trait("Categoria", "Integração API - Pedido")]
    public async Task AdicionarItem_NovoPedido_DeveRetornarComSucesso()
    {
        var itemInfo = new ItemViewModel
        {
            Id = new Guid("47a27a92-41a1-beff-92e6-4b3f5b77068b"),
            Quantidade = 2
        };
        await _testsFixture.RealizarLoginApi();
        _testsFixture.Client.AtribuirToken(_testsFixture.UsuarioToken);
        // Act
        var postResponse = await _testsFixture.Client.PostAsJsonAsync("api/carrinho", itemInfo);

        // Assert
        postResponse.EnsureSuccessStatusCode();
    }

    [Fact(DisplayName = "Remover item em pedido existente"), TestPriority(2)]
    [Trait("Categoria", "Integração API - Pedido")]
    public async Task RemoverItem_PedidoExistente_DeveRetornarComSucesso()
    {
        // Arrange
        var produtoId = new Guid("47a27a92-41a1-beff-92e6-4b3f5b77068b");
        await _testsFixture.RealizarLoginApi();
        _testsFixture.Client.AtribuirToken(_testsFixture.UsuarioToken);

        // Act
        var deleteResponse = await _testsFixture.Client.DeleteAsync($"api/carrinho/{produtoId}");

        // Assert
        deleteResponse.EnsureSuccessStatusCode();
    }
}