using Microsoft.Data.SqlClient;
using WFN.APIRest.Repository.Interfaces;
using WFN.Models.Models;

namespace WFN.APIRest.Repository;

public class BancoRepository: IBancoRepository
{
    private readonly string _connectionString;
    
    public BancoRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("ConnectionWFN");
    }
    
    public List<Entity_Banco> GetAllBancos()
    {
        List<Entity_Banco> bancos = new();
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Entity.Banco";
            SqlCommand command = new(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Entity_Banco banco = new()
                {
                    IDBanco = Convert.ToInt32(reader["ID_Entidad"]),
                    Nombre = reader["Nombre"].ToString(),
                    SWIFT = reader["SWIFT"].ToString(),
                    Pais = reader["Pais"].ToString(),
                    Sucursal = reader["Sucursal"].ToString(),
                    Telefono = reader["Telefono"].ToString(),
                };
                bancos.Add(banco);
            }
        }
        return bancos;
    }
    
    public Entity_Banco GetBancoById(int id)
    {
        Entity_Banco banco = new();
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Entity.Banco WHERE ID_Entidad = @Id";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                banco.IDBanco = Convert.ToInt32(reader["ID_Entidad"]);
                banco.Nombre = reader["Nombre"].ToString();
                banco.SWIFT = reader["SWIFT"].ToString();
                banco.Pais = reader["Pais"].ToString();
                banco.Sucursal = reader["Sucursal"].ToString();
                banco.Telefono = reader["Telefono"].ToString();
            }
        }
        return banco;
    }
    
    public void AddBanco(Entity_Banco banco)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Entity.Banco (Nombre, SWIFT, Pais, Sucursal, Telefono) VALUES (@Nombre, @SWIFT, @Pais, @Sucursal, @Telefono)";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Nombre", banco.Nombre);
            command.Parameters.AddWithValue("@SWIFT", banco.SWIFT);
            command.Parameters.AddWithValue("@Pais", banco.Pais);
            command.Parameters.AddWithValue("@Sucursal", banco.Sucursal);
            command.Parameters.AddWithValue("@Telefono", banco.Telefono);
            command.ExecuteNonQuery();
        }
    }
    
    public void UpdateBanco(Entity_Banco banco)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "UPDATE Entity.Banco SET Nombre = @Nombre, SWIFT = @SWIFT, Pais = @Pais, Sucursal = @Sucursal, Telefono = @Telefono WHERE ID_Entidad = @ID_Entidad";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@ID_Entidad", banco.IDBanco);
            command.Parameters.AddWithValue("@Nombre", banco.Nombre);
            command.Parameters.AddWithValue("@SWIFT", banco.SWIFT);
            command.Parameters.AddWithValue("@Pais", banco.Pais);
            command.Parameters.AddWithValue("@Sucursal", banco.Sucursal);
            command.Parameters.AddWithValue("@Telefono", banco.Telefono);
            command.ExecuteNonQuery();
        }
    }
    
    public void DeleteBanco(int id)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Entity.Banco WHERE ID_Entidad = @Id";
            SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}