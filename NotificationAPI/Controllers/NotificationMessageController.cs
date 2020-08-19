using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotificationAPI.Models;

namespace NotificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationMessageController : ControllerBase
    {
        private readonly NotificationDBContext _context;

        public NotificationMessageController(NotificationDBContext context)
        {
            _context = context;
        }

        // GET: api/NotificationMessage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationMessage>>> GetNotifications()
        {
            return await _context.Notifications.ToListAsync();
        }

        // GET: api/NotificationMessage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationMessage>> GetNotificationMessage(int id)
        {
            var notificationMessage = await _context.Notifications.FindAsync(id);

            if (notificationMessage == null)
            {
                return NotFound();
            }

            return notificationMessage;
        }

        // PUT: api/NotificationMessage/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificationMessage(int id, NotificationMessage notificationMessage)
        {
            notificationMessage.ID = id;

            _context.Entry(notificationMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationMessageExists(id))
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

        // POST: api/NotificationMessage
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NotificationMessage>> PostNotificationMessage(NotificationMessage notificationMessage)
        {
            _context.Notifications.Add(notificationMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificationMessage", new { id = notificationMessage.ID }, notificationMessage);
        }

        // DELETE: api/NotificationMessage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NotificationMessage>> DeleteNotificationMessage(int id)
        {
            var notificationMessage = await _context.Notifications.FindAsync(id);
            if (notificationMessage == null)
            {
                return NotFound();
            }

            _context.Notifications.Remove(notificationMessage);
            await _context.SaveChangesAsync();

            return notificationMessage;
        }

        private bool NotificationMessageExists(int id)
        {
            return _context.Notifications.Any(e => e.ID == id);
        }
    }
}
