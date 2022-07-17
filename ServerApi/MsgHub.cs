using Microsoft.AspNetCore.SignalR;

namespace ServerApi
{

    public class MsgHub : Hub//Hub为SignalR中hub的基类
    {
        public async Task BroadcastMsg(string msg)
        {
            await Clients.All.SendAsync("ReceiveMsg", msg);
        }
    }
}
