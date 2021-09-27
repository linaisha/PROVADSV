namespace Prova.Controllers
{
    [ProvaController]
    [Route("prova/livro")]
    public class LivroController : ControllerBase
    {
        private readonly DataContext _context;
        public LivroController(DataContext context)
        {
            _context = context
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] Livro livro){
            _context.Livro.Add(livro);
            await _context.SaveChangesAsync();
            return Created("", livro);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListAsync() => Ok(await _context.Livros.ToListAsync());

        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id){
            Livro livro = await _context.Livro.FindAsync(id);
            if(livro != null){
                return Ok(livro);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("delete/{name")]
        public async Taks<IActionResult> DeleteAsync([FromRoute] string name){
            Livro livro = _context.Livros.FirstOrDefault(
                livro => livro.Nome == name
            );
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return.Ok();
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] Livro livro){
            _context.Livro.Update(livro);
            await _context.SaveChangesAsync();
            return Ok(livro);
        }
    }
}