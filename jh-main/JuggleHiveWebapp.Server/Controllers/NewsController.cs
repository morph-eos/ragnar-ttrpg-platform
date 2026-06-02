using Microsoft.AspNetCore.Mvc;
using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services.Interfaces;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController(INewsService newsService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            return Ok(await newsService.GetAllNewsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(long id)
        {
            var news = await newsService.GetNewsByIdAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        [HttpGet("important")]
        public async Task<IActionResult> GetImportantNews()
        {
            var importantNews = await newsService.GetImportantNewsAsync();
            return Ok(importantNews);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNews(long id, News news)
        {
            if (id != news.Id)
            {
                return BadRequest();
            }

            await newsService.UpdateNewsAsync(news);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<News>> PostNews(News news)
        {
            await newsService.AddNewsAsync(news);
            return CreatedAtAction(nameof(GetNews), new { id = news.Id }, news);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(long id)
        {
            await newsService.DeleteNewsAsync(id);
            return NoContent();
        }
    }
}
