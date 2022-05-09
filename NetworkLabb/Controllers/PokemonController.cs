using Microsoft.AspNetCore.Mvc;

[Route("pokemon")]
[ApiController]
public class PokemonController : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        Pokemon poke = new Pokemon();
        poke.Name = "Ditto";
        poke.Hp = 2000;
        poke.Type = "Shapeshifter";

        return Ok(poke);
    }
}
