using Domain.Model;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private IDbConnection _conn;
        public ClienteRepository()
        {
            _conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bancoframework;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public Cliente GetClienteById(int id)
        {
            return _conn.QuerySingleOrDefault<Cliente>("SELECT * FROM Clientes WHERE Id = @Id", new {Id = id});
        }

        public void Add(Cliente cliente)
        {
            string sql = "INSERT INTO Clientes(Id, Nome, CPF, Saldo) VALUES(@Id, @Nome, @CPF, @Saldo)";
            _conn.Execute(sql, cliente);
        }

        public void Update(Cliente cliente)
        {
            string sql = "UPDATE Clientes SET Id = @Id, Nome = @Nome, CPF = @CPF, Saldo = @Saldo WHERE Id = @Id";
            _conn.Execute(sql, cliente);
        }
    }
}
