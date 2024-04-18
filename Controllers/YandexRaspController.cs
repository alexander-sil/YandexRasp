using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace YandexRasp.Controllers;

[ApiController]
[Route("api")]
public class YandexRaspController : ControllerBase
{

    private readonly ILogger<YandexRaspController> _logger;
    private readonly RaspModelDbContext _context;

    public YandexRaspController(RaspModelDbContext context, ILogger<YandexRaspController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    [Route("get-airport")]
    [SwaggerResponse(200, "Запрос выполнен успешно.")]
    [SwaggerResponse(400, "Запрос невалидный. Не указаны обязательные параметры.")]
    [SwaggerResponse(404, "Объект с указанным в запросе кодом не найден.")]    
    public IActionResult GetAirport([FromQuery] string from, [FromQuery] string to)
    {
        object model = RequestBroker.GetRaspModels(RequestBroker.SelectionType.Airport, DateTime.Now, from, to);

        if (model.GetType() == typeof(string)) return BadRequest((string)model);

        if (_context.RaspDBTable.Where(f => (f.From == from) && (f.To == to)).Count() == 0) {
            _context.RaspDBTable.AddRange(((List<RaspModel>)model).ToDBModels());
            _context.SaveChanges();
        }

        if (_context.RaspDBTable.Where(f => (f.From == from) && (f.To == to)).Count() != 0) {
            return Ok(_context.RaspDBTable.Where(f => (f.From == from) && (f.To == to)).ToModels().ToArray());
        }

        return Ok((List<RaspModel>)model);
    }

    [HttpGet]
    [Route("get-date")]
    [SwaggerResponse(200, "Запрос выполнен успешно.")]
    [SwaggerResponse(400, "Запрос невалидный. Не указаны обязательные параметры.")]
    [SwaggerResponse(404, "Объект с указанным в запросе кодом не найден.")]    
    public IActionResult GetDate([FromQuery] DateTime date, [FromQuery] string from, [FromQuery] string to)
    {
        object model = RequestBroker.GetRaspModels(RequestBroker.SelectionType.BothWays, date, from, to);

        if (model.GetType() == typeof(string)) return BadRequest((string)model);

        if (_context.RaspDBTable.Where(f => f.Date == date.ProcessDate()).Count() == 0) {
            _context.RaspDBTable.AddRange(((List<RaspModel>)model).ToDBModels());
            _context.SaveChanges();
        }

        if (_context.RaspDBTable.Where(f => f.Date == date.ProcessDate()).Count() != 0) {
            return Ok(_context.RaspDBTable.Where(f => f.Date == date.ProcessDate()).ToModels().ToArray());
        }

        return Ok((List<RaspModel>)model);
    }
}
