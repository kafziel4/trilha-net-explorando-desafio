using DesafioProjetoHospedagem.Models;

namespace DesafioProjetoHospedagemTests.Helpers
{
    public static class PessoaHelper
    {
        public static List<Pessoa> CriarHospedes(int quantidade)
        {
            List<Pessoa> hospedes = new();

            for (int i = 1; i <= quantidade; i++)
            {
                Pessoa pessoa = new(nome: $"Hóspede {i}");
                hospedes.Add(pessoa);
            }

            return hospedes;
        }
    }
}
