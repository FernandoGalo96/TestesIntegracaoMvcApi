using NerdStore.Bdd.Tests.Config;
using TechTalk.SpecFlow;

namespace NerdStore.Bdd.Tests.Usuario;

    [Binding]
[CollectionDefinition(nameof(AutomacaoWebTestsFixture))]
public class CommonSteps
{
    private readonly CadastroDeUsuarioTela _cadastroDeUsuarioTela;
    private readonly AutomacaoWebTestsFixture _testFixture;

    public CommonSteps(AutomacaoWebTestsFixture testFixture)
    {
        _testFixture = testFixture;
        _cadastroDeUsuarioTela = new CadastroDeUsuarioTela(testFixture.BrowserHelper);
    }

    [Given(@"Que o visitante está acessando o site da loja")]
    public void GivenQueOVisitanteEstaAcessandoOSiteDaLoja()
    {
        _cadastroDeUsuarioTela.AcessarSiteLoja();

        // Assert
        Assert.Contains(_testFixture.Configuration.DomainUrl, _cadastroDeUsuarioTela.ObterUrl());

    }


    [Then(@"Uma saudação com seu e-mail será exibida no menu superior")]
    public void ThenUmaSaudacaoComSeuE_MailSeraExibidaNoMenuSuperior()
    {
        Assert.Equal(_testFixture.Configuration.VitrineUrl, _cadastroDeUsuarioTela.ObterUrl());
    }


    [Then(@"Ele será redirecionado para a vitrine")]
    public void ThenEleSeraRedirecionadoParaAVitrine()
    {
        // Assert
        Assert.True(_cadastroDeUsuarioTela.ValidarSaudacaoUsuarioLogado(_testFixture.Usuario));
    }
}
