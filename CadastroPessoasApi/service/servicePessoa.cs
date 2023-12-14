using CadastroPessoasApi.Data;
using CadastroPessoasApi.ViewModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace CadastroPessoasApi.service
{
    public class servicePessoa
    {
        public IEnumerable<pesssoaViewModel> GetAll()
        {

            var repository = new Repository();
            return repository.GetAll().ToList();

        }
        public pesssoaViewModel GetById(int pessoaId)
        {

            var repository = new Repository();
            return repository.GetById(pessoaId);

         }

        public pesssoaViewModel GetByprimeironome(string primeironome)
        {
            var repository = new Repository();
            return repository.GetByprimeironome(primeironome);

        }

        public void Update(int pessoaId, string primeironome)
        {
            var repository = new Repository();
            repository.Update(pessoaId, primeironome);

        }

        public string Create(pesssoaViewModel pessoa)
        {

            if (pessoa == null)
                return "Os dados sao obrigatoriio";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.nomeMeio))
                return " O campo Nomemeio é obrigatório";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.ultimoNome))
                return " O campo UltimoNome é obrigatório";
            if (pessoa != null && string.IsNullOrEmpty(pessoa.CPF))
                return " O campo CPF é obrigarório";

            var repository = new Repository();
            return repository.Create(pessoa);

        }


    }
}
