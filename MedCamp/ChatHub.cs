using MedCamp.Controllers;
using MedCamp.Models;
using Microsoft.AspNetCore.SignalR;

namespace MedCamp
{
    public class ChatHub:Hub
    {
        private readonly MedCampContext _context;
        public ChatHub(MedCampContext context)
        {
            _context = context;
        }
        public override Task OnConnectedAsync()
        {
            var userId=new CommonController(_context).GetUserId(Context.GetHttpContext().Request);
            
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}
