using ImpostoPagoPorContribuinte.Entities;

namespace ImpostoPagoPorContribuinte.Entities
{
    class Companhia : Contribuinte
    {
        public int NumeroDeFuncionarios  { get; set; }

        public Companhia()
        {
        }

        public Companhia(string nome, double rendaAnual, int numeroDeFuncionarios)
            : base (nome, rendaAnual)
        {
            NumeroDeFuncionarios = numeroDeFuncionarios;
        }

        public override double Taxa()
        {
            if (NumeroDeFuncionarios > 10)
            {
                return RendaAnual * 0.14;
            }
            else
            {
                return RendaAnual * 0.16;
            }
        }
    }
}
