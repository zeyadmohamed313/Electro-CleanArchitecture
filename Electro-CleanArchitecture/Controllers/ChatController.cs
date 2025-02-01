using Electro.Data.AppDbContext;
using Electro_CleanArchitecture.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Electro_CleanArchitecture.Controllers
{
    [Authorize]
    public class ChatController : AppBaseController
    {
        private readonly Context _dbContext;

        public ChatController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("history/{userId}/{receiverId}")]
        public async Task<IActionResult> GetChatHistory(string userId, string receiverId)
        {
            var sender = await _dbContext.Users.FindAsync(int.Parse(userId));
            var receiver = await _dbContext.Users.FindAsync(int.Parse(receiverId));

            if (sender == null)
                return NotFound("Sender does not exist");
            if (receiver == null)
                return NotFound("Receiver does not exist");

            var messages = await _dbContext.ChatMessages
                .Where(m => (m.SenderId == userId && m.ReceiverId == receiverId) ||
                            (m.SenderId == receiverId && m.ReceiverId == userId))
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
            
            // Mark messages as read
            var unreadMessages = messages.Where(m => !m.IsRead && m.ReceiverId == userId);
            foreach (var message in unreadMessages)
            {
                message.IsRead = true;
            }

            await _dbContext.SaveChangesAsync();

            return Ok(messages);
        }

        [HttpGet("unread/{userId}")]
        public async Task<IActionResult> GetUnreadCount(string userId)
        {
            var unreadCount = await _dbContext.ChatMessages
                .CountAsync(m => m.ReceiverId == userId && !m.IsRead);
            return Ok(unreadCount);
        }
    }
}