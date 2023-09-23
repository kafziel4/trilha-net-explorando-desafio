namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        private const int QuantidadeDiasParaObterDesconto = 10;
        private const decimal PorcentagemDesconto = 0.1M;

        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados) => DiasReservados = diasReservados;

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite.Capacidade < hospedes.Count)
                throw new ArgumentException("A quantidade de hóspedes não pode exceder a capacidade da suíte");

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite) => Suite = suite;

        public int ObterQuantidadeHospedes() => Hospedes.Count;

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (ElegivelDesconto())
                valor *= 1 - PorcentagemDesconto;

            return valor;
        }

        private bool ElegivelDesconto() => DiasReservados >= QuantidadeDiasParaObterDesconto;
    }
}