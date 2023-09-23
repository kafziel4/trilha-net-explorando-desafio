using DesafioProjetoHospedagem.Models;

namespace DesafioProjetoHospedagemTests.Helpers
{
    public static class SuiteHelper
    {
        public static Suite CriarSuite(int capacidade, decimal valorDiaria = 10) =>
            new(tipoSuite: "Premium", capacidade: capacidade, valorDiaria: valorDiaria);
    }
}
