using NerdStore.Bdd.Tests.Config;
using System;
using TechTalk.SpecFlow;

namespace NerdStore.Bdd.Tests.Usuario;

[Binding]
[CollectionDefinition(nameof(AutomacaoWebTestsFixture))]
public class CadastroDeUsuariosSteps
{
    private readonly CadastroDeUsuarioTela _cadastroDeUsuarioTela;
    private readonly AutomacaoWebTestsFixture _testFixture;

    public CadastroDeUsuariosSteps(AutomacaoWebTestsFixture testFixture)
    {
        _testFixture = testFixture;
        _cadastroDeUsuarioTela = new CadastroDeUsuarioTela(testFixture.BrowserHelper);
    }

    [When(@"Ele clicar em registrar")]  
    public void QuandoEleClicarEmRegistrar()
    {
        // Act
        _cadastroDeUsuarioTela.ClicarNoLinkRegistrar();

        // Assert
        Assert.Contains(_testFixture.Configuration.RegisterUrl, _cadastroDeUsuarioTela.ObterUrl());
    }

    [When(@"Preencher os dados do formulario")]
    public void QuandoPreencherOsDadosDoFormulario(Table table)
    {
        // Arrange
        _testFixture.GerarDadosUsuario();
        var usuario = _testFixture.Usuario;

        // Act
        _cadastroDeUsuarioTela.PreencherFormularioRegistro(usuario);

        // Assert
        Assert.True(_cadastroDeUsuarioTela.ValidarPreenchimentoFormularioRegistro(usuario));
    }

    [When(@"Clicar no botão registrar")]
    public void QuandoClicarNoBotaoRegistrar()
    {
        _cadastroDeUsuarioTela.ClicarNoBotaoRegistrar();
    }

  

  

    [When(@"Preencher os dados do formulario com uma senha sem maiusculas")]
    public void WhenPreencherOsDadosDoFormularioComUmaSenhaSemMaiusculas(Table table)
    {
        throw new PendingStepException();
    }

    [Then(@"Ele receberá uma mensagem de erro que a senha precisa conter uma letra maiuscula")]
    public void ThenEleReceberaUmaMensagemDeErroQueASenhaPrecisaConterUmaLetraMaiuscula()
    {
        throw new PendingStepException();
    }

    [When(@"Preencher os dados do formulario com uma senha sem caractere especial")]
    public void WhenPreencherOsDadosDoFormularioComUmaSenhaSemCaractereEspecial(Table table)
    {
        throw new PendingStepException();
    }

    [Then(@"Ele receberá uma mensagem de erro que a senha precisa conter um caractere especial")]
    public void ThenEleReceberaUmaMensagemDeErroQueASenhaPrecisaConterUmCaractereEspecial()
    {
        throw new PendingStepException();
    }
}
