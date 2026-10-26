using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/blogposts")]
public class BlogpostsController : ControllerBase
{
    private readonly BlogpostService _blogpostService;

    public BlogpostsController(BlogpostService blogpostService)
    {
        _blogpostService = blogpostService;
    }

    // GET all blogposts
    [HttpGet]
    public async Task<ActionResult<List<BlogpostDto>>> GetAll()
    {
        var blogposts = await _blogpostService.GetAllAsync();

        return Ok(blogposts);
    }

    // GET blogpost by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<BlogpostDto>> GetById(int id)
    {
        var blogpost = await _blogpostService.GetByIdAsync(id);

        if (blogpost == null)
        {
            return NotFound();
        }

        return Ok(blogpost);
    }

    // CREATE blogpost
    [HttpPost]
    public async Task<ActionResult<BlogpostDto>> Create(CreateBlogpostDto dto)
    {
        var blogpost = await _blogpostService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetById), new { id = blogpost.Id }, blogpost);
    }

    // UPDATE blogpost
    [HttpPut("{id}")]
    public async Task<ActionResult<BlogpostDto>> Update(int id, UpdateBlogpostDto dto)
    {
        var blogpost = await _blogpostService.UpdateAsync(id, dto);

        if (blogpost == null)
        {
            return NotFound();
        }

        return Ok(blogpost);
    }

    // DELETE blogpost
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _blogpostService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}