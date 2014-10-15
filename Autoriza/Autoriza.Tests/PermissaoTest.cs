using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autoriza.Models;
using NUnit.Framework;

namespace Autoriza.Tests
{

    [TestFixture]
    class PermissaoTest
    {

        [Test]
        public void DeveCompararDuasPermissoesERetornarTrue()
        {

            Permissao permissao1 = new Permissao() { Id = 1, Nome = "consulta_perfil" };
            Permissao permissao2 = new Permissao() { Id = 1, Nome = "consulta_perfil" };

            Assert.True(permissao1.Equals(permissao2));

        }

        [Test]
        public void DeveCompararUmaPermissaoComIdEOutraSemERetornarTrue()
        {

            Permissao permissao1 = new Permissao() { Id = 1, Nome = "consulta_perfil" };
            Permissao permissao2 = new Permissao() { Id = 0, Nome = "consulta_perfil" };

            Assert.True(permissao1.Equals(permissao2));
        }

        [Test]
        public void DeveCompararDuasPermissoesComOMesmoENomesDiferentesERetornarTrue()
        {

            Permissao permissao1 = new Permissao() { Id = 1, Nome = "consulta_perfil" };
            Permissao permissao2 = new Permissao() { Id = 1, Nome = "consulta_usuario" };

            Assert.True(permissao1.Equals(permissao2));
        }

        [Test]
        public void DeveCompararDuasPermissoesComIdEENomesDiferentesERetornarFalse()
        {

            Permissao permissao1 = new Permissao() { Id = 1, Nome = "consulta_perfil" };
            Permissao permissao2 = new Permissao() { Id = 0, Nome = "consulta_usuario" };

            Assert.False(permissao1.Equals(permissao2));
        }

    }
}
