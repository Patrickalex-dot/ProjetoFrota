using ProjetoFrota.ViewModelSalvar;

namespace ProjetoFrota.Repositorys
{
    public class MotoristaRepository
    {
        private readonly string Conexao = @"Data Source=ITELABD14\SQLEXPRESS;Initial Catalog=ProjetoFrota;Integrated Security=True;";

        public bool Salvar (SalvarMotoristaViewModel salvarMotorista)
        {
            try
            {
                var query = @"INSERT INTO Motorista 
                            (Nome,Endereco, Cpf)
                            VALUES (@nome,@endereco,@cpf) ";

            }
        }
    }
}
