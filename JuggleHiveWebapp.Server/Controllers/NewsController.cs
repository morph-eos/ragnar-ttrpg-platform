using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JuggleHiveWebapp.Server.Models;

namespace JuggleHiveWebapp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController(PostgresContext context) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            return await context.News.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(long id)
        {
            var news = await context.News.FindAsync(id);

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNews(long id, News news)
        {
            if (id != news.Id)
            {
                return BadRequest();
            }

            context.Entry(news).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<News>> PostNews(News news)
        {
            context.News.Add(news);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NewsExists(news.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNews", new { id = news.Id }, news);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(long id)
        {
            var news = await context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            context.News.Remove(news);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewsExists(long id)
        {
            return context.News.Any(e => e.Id == id);
        }
    }
}
