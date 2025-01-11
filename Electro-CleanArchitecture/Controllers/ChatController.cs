using Electro.Data.AppDbContext;
using Electro_CleanArchitecture.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Electro_CleanArchitecture.Controllers
{
    public class ChatController:AppBaseController
    {
        private readonly Context _dbContext;

        public ChatController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("history/{userId}/{receiverId}")]
        public async Task<IActionResult> GetChatHistory(string userId, string receiverId)
        {
            var Sender = await _dbContext.Users.FindAsync(int.Parse(userId));
            var Receiver = await _dbContext.Users.FindAsync(int.Parse(receiverId));

            if(Sender == null) 
                return NotFound("Sender Doesnot Exsist");
            if (Receiver == null)
                return NotFound("Receiver Doesnot Exsist");

            var messages = await _dbContext.ChatMessages
                .Where(m => (m.SenderId == userId && m.ReceiverId == receiverId) ||
                            (m.SenderId == receiverId && m.ReceiverId == userId))
                .OrderBy(m => m.Timestamp)
                .ToListAsync();

            return Ok(messages);
        }
    }
}
