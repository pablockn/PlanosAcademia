using System;


namespace PlanosAcademia
{


    class Plano
    {
        public string Nome { get; set; }
        public double PrecoBase { get; set; }
        public int DuracaoMeses { get; set; }


        public Plano(string nome, double precoBase, int duracaoMeses)
        {
            Nome = nome;
            PrecoBase = precoBase;
            DuracaoMeses = duracaoMeses;
        }


        public virtual double CalcularPreco()
        {
            return PrecoBase * DuracaoMeses;
        }


        public virtual void ExibirDetalhes()
        {
            Console.WriteLine($"Plano: {Nome}");
            Console.WriteLine($"Duração: {DuracaoMeses} mês(es)");
            Console.WriteLine($"Preço Mensal Base: R$ {PrecoBase:F2}");
            Console.WriteLine($"Preço Total Final: R$ {CalcularPreco():F2}");
        }
    }


    class PlanoMensal : Plano
    {
        public double Desconto { get; set; } = 0.0;


        public PlanoMensal(string nome, double precoBase) 
            : base(nome, precoBase, 1)
        {
        }


        public override double CalcularPreco()
        {
            return PrecoBase * DuracaoMeses;
        }


        public override void ExibirDetalhes()
        {
            base.ExibirDetalhes();
            Console.WriteLine("Desconto: Sem desconto");
        }
    }


    class PlanoTrimestral : Plano
    {
        public double Desconto { get; set; } = 0.05;
        public string BeneficiosExtras { get; set; }


        public PlanoTrimestral(string nome, double precoBase, string beneficios) 
            : base(nome, precoBase, 3)
        {
            BeneficiosExtras = beneficios;
        }


      public override double CalcularPreco()
{
    // Calcula o valor mensal com o desconto
    return PrecoBase * (1 - Desconto); //  150 - 5% = R$ 142,50 por mês
}


        public override void ExibirDetalhes()
        {
            base.ExibirDetalhes();
            Console.WriteLine("Desconto: 5%");
            Console.WriteLine($"Benefícios Extras: {BeneficiosExtras}");
        }
    }


    class PlanoAnual : Plano
    {
        public double Desconto { get; set; } = 0.15;
        public string BeneficiosExtras { get; set; }


        public PlanoAnual(string nome, double precoBase, string beneficios) 
            : base(nome, precoBase, 12)
        {
            BeneficiosExtras = beneficios;
        }


        public override double CalcularPreco()
{
    return PrecoBase * (1 - Desconto); //  200 - 15% = R$ 170,00 por mês
}


        public override void ExibirDetalhes()
        {
            base.ExibirDetalhes();
            Console.WriteLine("Desconto: 15%");
            Console.WriteLine($"Benefícios Extras: {BeneficiosExtras}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            PlanoMensal mensal = new PlanoMensal("Plano Mensal", 70.00);
            
            PlanoTrimestral trimestral = new PlanoTrimestral(
                "Plano Trimestral", 
                150, 
                "Avaliação física grátis"
            );
            
            PlanoAnual anual = new PlanoAnual(
                "Plano Anual VIP", 
                200, 
                "Acesso total + 1 convidado por mês"
            );


            Console.WriteLine("SISTEMA DE PLANOS DA ACADEMIA\n");
            mensal.ExibirDetalhes();
            trimestral.ExibirDetalhes();
            anual.ExibirDetalhes();
        }
    }
}