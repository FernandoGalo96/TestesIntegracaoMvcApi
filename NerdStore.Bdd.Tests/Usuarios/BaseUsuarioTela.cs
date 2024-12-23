﻿

using NerdStore.Bdd.Tests.Config;
using NerdStore.BDD.Tests.Config;

namespace NerdStore.Bdd.Tests.Usuario;


    public abstract class BaseUsuarioTela : PageObjectModel
    {
        protected BaseUsuarioTela(SeleniumHelper helper) : base(helper)
        {
        }

        public void AcessarSiteLoja()
        {
            Helper.IrParaUrl(Helper.Configuration.DomainUrl);
        }

    public bool ValidarSaudacaoUsuarioLogado(Usuario usuario)
    {
        return Helper.ObterTextoElementoPorId("saudacaoUsuario").Contains(usuario.Email);
    }
}

