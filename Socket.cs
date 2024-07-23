namespace TatehamaInterlocking;

using Microsoft.VisualBasic;
using SocketIO.Serializer.SystemTextJson;
using SocketIOClient;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;
using TatehamaInterlocking.Tsuzaki;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

public class TrackCircuitInfo
{
    public string signalName { get; set; }
    public string signalType { get; set; }
    public string signalPhase { get; set; }
    public string? diaName { get; set; }
    public bool isClosure { get; set; }
    public StationStatus stationStatus { get; set; }

    public bool IsDiaEqual(TrackCircuitInfo info)
    {
        if (info == null) return false;
        if (info.signalName == signalName && info.diaName == diaName && info.stationStatus == stationStatus) return true;
        return false;
    }
    public override string ToString()
    {
        return $"{signalName}/{isClosure}/{stationStatus}/{diaName}";
    }
}
public enum StationStatus
{
    /// <summary>
    /// 進路未開通
    /// </summary>
    ROUTE_CLOSED,
    /// <summary>
    /// 進路開通
    /// </summary>
    ROUTE_OPENED,
    /// <summary>
    /// 進路進入中
    /// </summary>
    ROUTE_ENTERING,
    /// <summary>
    /// 進路進入完了
    /// </summary>
    ROUTE_ENTERED
}

public class Socket
{
    private bool isconnect;
    private SocketIO client;
    public Socket(string serverAddress)
    {
        isconnect = false;
        client = new SocketIO(serverAddress);
        var config = new JsonSerializerOptions();
        config.Converters.Add(new JsonStringEnumConverter());
        client.Serializer = new SystemTextJsonSerializer(config);
        connect();
        Task.Run(async () => StartUpdateLoop());
    }

    private Dictionary<string, TrackCircuitInfo> beforeTrackInfo;

    private async void StartUpdateLoop()
    {
        while (true)
        {
            try
            {
                var timer = Task.Delay(50);
                if (isconnect)
                {

                    List<TrackCircuitInfo> List = await getAllSignal();

                    var first = beforeTrackInfo == null;
                    if (first)
                    {
                        beforeTrackInfo = new Dictionary<string, TrackCircuitInfo>();
                    }

                    for (int i = 0; i < List.Count; i++)
                    {
                        if (first)
                        {
                            MainWindow.TrackChenge(List[i], true);
                            beforeTrackInfo[List[i].signalName] = List[i];
                            continue;
                        }
                        else if (!List[i].IsDiaEqual(beforeTrackInfo[List[i].signalName]))
                        {
                            MainWindow.TrackChenge(List[i]);
                            beforeTrackInfo[List[i].signalName] = List[i];
                        }
                    }
                }
                await timer;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }

    public async Task connect()
    {
        await client.ConnectAsync();
        isconnect = true;
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

    public async Task<string?> routeCancel(string signalName)
    {
        await client.EmitAsync("routeCancel", signalName);
        var tcs = new TaskCompletionSource<string?>();
        client.On("routeCancelResult", response =>
        {
            var elapsedData = response.GetValue<string?>();
            tcs.SetResult(elapsedData);
        });
        return await tcs.Task;
    }


    public async void enterSignal(string signalName, string trainName)
    {
        var data = new
        {
            diaName = trainName,
            signalName = signalName
        };
        await client.EmitAsync("enterSignal", data);
    }

    public async void leaveSignal(string signalName, string trainName)
    {
        var data = new
        {
            diaName = trainName,
            signalName = signalName
        };
        await client.EmitAsync("leaveSignal", data);
    }
    public async void enteringComplete(string signalName, string trainName)
    {
        var data = new
        {
            diaName = trainName,
            signalName = signalName
        };
        await client.EmitAsync("enteringComplete", data);
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