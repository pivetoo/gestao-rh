using GestorRH.Application.DTOs;
using GestorRH.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace GestorRH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCargos()
        {
            var cargos = await _cargoService.ObterTodosCargos();
            return Ok(cargos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCargoById(int id)
        {
            var cargo = await _cargoService.ObterCargoPorId(id);
            return Ok(cargo);
        }

        [HttpPost]
        public async Task<IActionResult> PostCargo(CargoDTO cargoDto)
        {
            await _cargoService.AdicionarCargo(cargoDto);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutCargo(CargoDTO cargoDto)
        {
            await _cargoService.AtualizarCargo(cargoDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            await _cargoService.RemoverCargo(id);
            return NoContent();
        }
    }
}
