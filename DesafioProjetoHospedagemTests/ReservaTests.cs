using DesafioProjetoHospedagem.Models;
using DesafioProjetoHospedagemTests.Helpers;

namespace DesafioProjetoHospedagemTests
{
    public class ReservaTests
    {
        [Theory]
        [InlineData(3)]
        [InlineData(2)]
        public void CadastrarHospedes_CapacidadeMaiorIgualHospedes_DeveSerAtribuido(int capacidade)
        {
            // Arrange
            List<Pessoa> hospedes = PessoaHelper.CriarHospedes(quantidade: 2);
            Suite suite = SuiteHelper.CriarSuite(capacidade: capacidade);
            Reserva reserva = ReservaHelper.CriarReserva(diasReservados: 5);
            reserva.CadastrarSuite(suite);

            // Act
            reserva.CadastrarHospedes(hospedes);

            // Assert
            reserva.Hospedes.Should().BeSameAs(hospedes);
        }

        [Fact]
        public void CadastrarHospedes_CapacidadeMenorQueHospedes_DeveLancarExcecao()
        {
            // Arrange
            List<Pessoa> hospedes = PessoaHelper.CriarHospedes(quantidade: 2);
            Suite suite = SuiteHelper.CriarSuite(capacidade: 1);
            Reserva reserva = ReservaHelper.CriarReserva(diasReservados: 5);
            reserva.CadastrarSuite(suite);

            // Act
            Action cadastrar = () => reserva.CadastrarHospedes(hospedes);

            // Assert
            cadastrar.Should().Throw<ArgumentException>()
                .WithMessage("A quantidade de hóspedes não pode exceder a capacidade da suíte");
        }

        [Fact]
        public void ObterQuantidadeHospedes_HospedesCadastrados_DeveRetornarQuantidadeHospedes()
        {
            // Arrange
            List<Pessoa> hospedes = PessoaHelper.CriarHospedes(quantidade: 2);
            Suite suite = SuiteHelper.CriarSuite(capacidade: 2);
            Reserva reserva = ReservaHelper.CriarReserva(diasReservados: 5);
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);

            // Act
            int quantidade = reserva.ObterQuantidadeHospedes();

            // Assert
            quantidade.Should().Be(2);
        }
    }
}