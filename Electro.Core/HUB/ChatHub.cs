using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Electro.Data.AppDbContext;
using Electro.Data.Entites;
using Microsoft.AspNetCore.SignalR;

namespace Electro.Core.HUB
{
    public class ChatHub : Hub
    {
        private readonly Context _dbContext;

        public ChatHub(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SendMessage(string senderId, string receiverId, string message)
        {
            // Save the message to the database
            var chatMessage = new ChatMessage
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Message = message
            };
            await _dbContext.ChatMessages.AddAsync(chatMessage);
            await _dbContext.SaveChangesAsync();

            // Send the message to the receiver
            await Clients.User(receiverId).SendAsync("ReceiveMessage", senderId, message);
        }
    }
}
