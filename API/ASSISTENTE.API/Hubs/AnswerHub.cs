using Microsoft.AspNetCore.SignalR;

namespace ASSISTENTE.API.Hubs;

public sealed class AnswerHub : Hub<IAnswerHub>
{
    public override async Task OnConnectedAsync()
    {
        await Clients.Client(Context.ConnectionId).InitConnection(Context.ConnectionId);
            
        await base.OnConnectedAsync();
    }
}

public interface IAnswerHub
{
    Task ReceiveAnswer(string message);
    Task InitConnection(string connectionId);
}