using Microsoft.AspNetCore.Mvc;
using WFN.APIRest.Repository.Interfaces;
using WFN.Models.Models;

namespace WFN.APIRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BancoController: ControllerBase
{
    private readonly IBancoRepository _bancoRepository;
    
    public BancoController(IBancoRepository bancoRepository)
    {
        _bancoRepository = bancoRepository;
    }
    
    [HttpGet]
    public IActionResult GetAllBancos()
    {
        return Ok(_bancoRepository.GetAllBancos());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetBancoById(int id)
    {
        return Ok(_bancoRepository.GetBancoById(id));
    }
    
    [HttpPost]
    public IActionResult AddBanco([FromBody] Entity_Banco banco)
    {
        _bancoRepository.AddBanco(banco);
        return Ok("Banco agregado con exito");
    }
    
    [HttpPut]
    public IActionResult UpdateBanco([FromBody] Entity_Banco banco)
    {
        _bancoRepository.UpdateBanco(banco);
        return Ok("Banco actualizado con exito");
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteBanco(int id)
    {
        _bancoRepository.DeleteBanco(id);
        return Ok("Banco eliminado con exito");
    }
}