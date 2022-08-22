namespace ProjetoFrota
{
    public class CaminhaoRepository
    {
     private readonly string _connection = @"Data Source=PATRICK\SQLEXPRESS;Initial Catalog=Frotas;Integrated Security=True;";
     public bool SalvarCliente(CadastrarCaminhaoViewModel SalvarCaminhaoViewModel)
        {
            try
            {
                var query = @"INSERT INTO CAMINHAO
                                (Modelo,Placa)"
                                VALUES ("@Modelo,@Placa")
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                   
                }
            }
        }

    }
}
