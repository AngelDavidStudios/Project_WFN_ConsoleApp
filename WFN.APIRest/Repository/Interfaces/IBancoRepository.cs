using WFN.Models.Models;

namespace WFN.APIRest.Repository.Interfaces;

public interface IBancoRepository
{
    List<Entity_Banco> GetAllBancos();
    Entity_Banco GetBancoById(int id);
    
    // CRUD
    void AddBanco(Entity_Banco banco);
    void UpdateBanco(Entity_Banco banco);
    void DeleteBanco(int id);
}