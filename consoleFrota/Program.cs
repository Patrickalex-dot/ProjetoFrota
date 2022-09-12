using System;

namespace consoleFrota
{
    internal class Program
    {

        enum Operacao
        {
            Sair,
            Cadastrar,
            Atualizar,
            Remover,


        }
        enum Operacao2
        {
            CadastrarCaminhao,
            CadastrarMotorista,
            CadastrarViagem,
        }
        enum Operacao3
        {
            AtualizarCaminhao,
            AtualizarMotorista,

        }
        enum Operaacao4
        {
            RemoverCaminhao,
            RemoverMotorista,
            RemoverViagem,
        }
      
        
        static void Main(string[] args)
        {
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine("-_-_-_-_-_-_-_-MENU_-_-_-_-_-_-_-_");
            Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Atualizar");
            Console.WriteLine("3 - Remover");
        }
        
    }
}
