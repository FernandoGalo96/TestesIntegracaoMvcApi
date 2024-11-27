using System;
using TechTalk.SpecFlow;

namespace NerdStore.Bdd.Tests.Usuario
{
    [Binding]
    public class Usuario_LoginStepDefinitions
    {
        [When(@"Ele clicar em login")]
        public void WhenEleClicarEmLogin()
        {
            throw new PendingStepException();
        }

        [When(@"Preencher os dados do formulario de login")]
        public void WhenPreencherOsDadosDoFormularioDeLogin(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"Clicar no botão login")]
        public void WhenClicarNoBotaoLogin()
        {
            throw new PendingStepException();
        }
    }
}
