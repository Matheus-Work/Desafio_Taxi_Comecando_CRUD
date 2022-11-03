using System;
/*A Companhia de Taxi LocalCerto armazena os dados de seus motoristas (nome,numero do taxí, Kper, ativo).
 * Elabore um programa capaz de ler os dados de n motoristas (utilizar um vetor de registros para
 * armazenar esses dados). Em seguida, o programa deve imprimir um relatório.
 * O valor a receber é calculado multiplicando-se a quantiade de Kper (Quilometros percorrido) por R$1,20. 
 * Ao final o programa deve também exibit todos os dados do motorista com maior valor a receber.
 * E depois, altere, exclua e consulte algum motorista, e ao final de cada ação, imprima a lista novamente.
 */
namespace taxi
{
    class Program
    {
        public struct taxi
        {
            public string nome;
            public int numero_taxi;
            public double kper;
            public int ativo;
        }
        static void Main(string[] args)
        {
            int numero_motoristas = 0;
            double valor_receber = 0;
            double maior = 0;
            string nomeDigitado = "";

            contarMotorista(ref numero_motoristas);
            Console.WriteLine("\n---------------\n");
            taxi[] taxi = new taxi[numero_motoristas];
            createVetor(ref numero_motoristas, taxi);
            Console.WriteLine("\n---------------\n");
            readVetor(valor_receber, ref numero_motoristas, taxi);
            Console.WriteLine("\n---------------\n");
            verificaMaior(taxi, ref numero_motoristas);
            Console.WriteLine("\n---------------\n");
            update(taxi, nomeDigitado, ref numero_motoristas);
            Console.WriteLine("\n---------------\n");
            readVetor(valor_receber, ref numero_motoristas, taxi);
            Console.WriteLine("\n---------------\n");
            delete(taxi, nomeDigitado, ref numero_motoristas);
            Console.WriteLine("\n---------------\n");
            readVetor(valor_receber, ref numero_motoristas, taxi);
            Console.WriteLine("\n---------------\n");
            consultar(taxi, nomeDigitado, ref numero_motoristas, valor_receber);
        }
        public static void contarMotorista(ref int numero_motoristas)
        {
            Console.WriteLine("Quantos motoristas tem?");
            numero_motoristas = int.Parse(Console.ReadLine());
        }
        public static void createVetor(ref int numero_motoristas, taxi[] taxi)
        {
            for (int i = 0; i < numero_motoristas; i++)
            {
                Console.WriteLine("Nome do {0}º motorista", i + 1);
                taxi[i].nome = Console.ReadLine();
                Console.WriteLine("Número do taxi");
                taxi[i].numero_taxi = int.Parse(Console.ReadLine());
                Console.WriteLine("Quilometros percorridos");
                taxi[i].kper = double.Parse(Console.ReadLine());
                Console.WriteLine("Ativo ? 1 para sim / 0 para não");
                taxi[i].ativo = int.Parse(Console.ReadLine());
                Console.WriteLine("-------------");
            }
        }
        public static void readVetor(double valor_receber, ref int numero_motoristas, taxi[] taxi)
        {
            Console.WriteLine("Nome    |    Número do Táxi    |    Valor à receber     |    Ativo ");

            for (int i = 0; i < numero_motoristas; i++)
            {
                if (taxi[i].ativo == 1)
                {
                    valor_receber = taxi[i].kper * 1.2;
                    Console.WriteLine("{0}         {1}                            {2:F2}           {3}", taxi[i].nome, taxi[i].numero_taxi, valor_receber, taxi[i].ativo);
                }
            }
        }
        public static void verificaMaior(taxi[] taxi, ref int numero_motoristas)
        {
            int p = 0;
            double maior = taxi[0].kper;
            for (int i = 0; i < numero_motoristas; i++)
            {

                if (taxi[i].kper > maior)
                {
                    maior = taxi[i].kper;
                    p = i;
                }
            }
            double precoMaior = maior * 1.2;
            Console.WriteLine("O motorista com maior valor a receber foi o {0} com o preço da viagem de {1:F2}, e o número do taxi é igual a {2}", taxi[p].nome, precoMaior, taxi[p].numero_taxi);

        }
        public static void update(taxi[] taxi, string nomeDigitado, ref int numero_motoristas)
        {
            Console.WriteLine("Alterar um taxista: ");
            Console.WriteLine("Informe seu nome: ");
            nomeDigitado = Console.ReadLine();
            for (int i = 0; i < numero_motoristas; i++)
            {
                if (nomeDigitado == taxi[i].nome)
                {
                    Console.WriteLine("Nome do motorista {0}: ", taxi[i].nome);
                    taxi[i].nome = Console.ReadLine();
                    Console.WriteLine("Número do taxi");
                    taxi[i].numero_taxi = int.Parse(Console.ReadLine());
                    Console.WriteLine("Quilometros percorridos");
                    taxi[i].kper = double.Parse(Console.ReadLine());
                    Console.WriteLine("-------------");
                }
            }
        }
        public static void delete(taxi[] taxi, string nomeDigitado, ref int numero_motoristas)
        {
            Console.WriteLine("Excluir um taxista: ");
            Console.WriteLine("Informe seu nome: ");
            nomeDigitado = Console.ReadLine();
            for (int i = 0; i < numero_motoristas; i++)
            {
                if (nomeDigitado == taxi[i].nome)
                {
                    taxi[i].ativo = 0;
                }
            }
        }
        public static void consultar(taxi[] taxi, string nomeDigitado, ref int numero_motoristas, double valor_receber)
        {
            Console.WriteLine("Consultar um taxista: ");
            Console.WriteLine("Informe seu nome: ");
            nomeDigitado = Console.ReadLine();
            for (int i = 0; i < numero_motoristas; i++)
            {
                if (nomeDigitado == taxi[i].nome)
                {
                    valor_receber = taxi[i].kper * 1.2;
                    Console.WriteLine("Nome    |    Número do Táxi    |    Valor à receber     |    Ativo ");
                    Console.WriteLine("{0}         {1}                            {2:F2}           {3}",
                        taxi[i].nome, taxi[i].numero_taxi, valor_receber, taxi[i].ativo);
                }
            }
        }

    }
}
