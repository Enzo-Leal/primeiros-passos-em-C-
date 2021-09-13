using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        // to do: adicionar aluno
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine(); 

                        Console.WriteLine("informe a nota do aluno: ");


                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("valor da nota tem que ser um  decimal!");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;

                    case "2":
                        // to do: listar alunos
                        foreach(var a in alunos){
                            if (!string.IsNullOrEmpty(a.Nome))
                                {
                                    Console.WriteLine($"aluno: {a.Nome} - NOTA: {a.Nota}");  
                                }

                            
                        }
                        break;

                    case "3":
                        // to do; calcular media  geral
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitogeral;
                        if(mediaGeral < 2)
                        {
                            conceitogeral = Conceito.E;
                        }
                        else if( mediaGeral < 4)
                        {
                            conceitogeral = Conceito.D;
                        }
                        else if( mediaGeral < 6)
                        {
                            conceitogeral = Conceito.C;
                        }
                        else if( mediaGeral < 8)
                        {
                            conceitogeral = Conceito.B;
                        }
                        else
                        {
                            conceitogeral = Conceito.A;
                        }

                        Console.WriteLine($"MEDIA GERAL: {mediaGeral} - CONCEITO: {conceitogeral}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opçao desejada: ");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular media geral");
            Console.WriteLine("x- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
