using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Electro.Data.AppDbContext;
using Electro.Data.Entites;
using Microsoft.AspNetCore.SignalR;

namespace Electro.Core.HUB
{
    public class chatHub : Hub
    {
        private readonly Context _dbContext;
        private static Dictionary<string, string> _userConnections = new();

        public chatHub(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                _userConnections[userId] = Context.ConnectionId;
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                _userConnections.Remove(userId);
            }
            await base.OnDisconnectedAsync(exception);
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

            // Get receiver's connection ID
            if (_userConnections.TryGetValue(receiverId, out string connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessage", chatMessage);
            }
            // Send back to sender to confirm
            if (_userConnections.TryGetValue(senderId, out string senderConnectionId))
            {
                await Clients.Client(senderConnectionId).SendAsync("ReceiveMessage", chatMessage);
            }
        }

        public async Task MarkAsRead(string messageId, string userId)
        {
            var message = await _dbContext.ChatMessages.FindAsync(int.Parse(messageId));
            if (message != null && message.ReceiverId == userId)
            {
                message.IsRead = true;
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
