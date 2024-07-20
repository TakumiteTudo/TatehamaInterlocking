namespace TatehamaInterlocking;
using SocketIOClient;

public class TrackCircuitInfo
{
   public string signalName { get; set; }
   public string signalType { get; set; }
   public double signalPhase { get; set; }
   public string? diaName { get; set; }
}

public class Socket
{

   private SocketIO client;
   public Socket(string serverAddress)
   {
      client = new SocketIO(serverAddress);
      Task.Run(async () => await client.ConnectAsync());
   }


   public async Task connect()
   {
      await client.ConnectAsync();
   }

   public async Task<string?> routeOpen(string signalName)
   {
      await client.EmitAsync("routeOpen", signalName);
      var tcs = new TaskCompletionSource<string?>();
      client.On("routeOpenResult", response =>
      {
         var elapsedData = response.GetValue<string?>();
         tcs.SetResult(elapsedData);
      });
      return await tcs.Task;
   }
   
   public async Task<List<TrackCircuitInfo>> getAllSignal()
   {
      await client.EmitAsync("getAllSignal");
      var ecs = new TaskCompletionSource<List<TrackCircuitInfo>>();
      client.On("getAllSignalResult", response =>
      {
         var route = response.GetValue<List<TrackCircuitInfo>>();
         ecs.SetResult(route);
      });
      return await ecs.Task; 
   }
   
}