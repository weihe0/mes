using HslCommunication.Profinet.Siemens;
using Microsoft.AspNetCore.Mvc;

namespace mes_asp_net_core.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class PlcController:ControllerBase
{
    public static readonly SiemensS7Net S7Client = new SiemensS7Net(SiemensPLCS.S1200, "192.168.0.1");

    static PlcController()
    {
        S7Client.ConnectServer();
    }
    
    [Route("start")]
    [HttpPost]
    public ActionResult Start(StartParameter parameter)
    {
        if (!S7Client.ReadBool("DB4.DBX6.2").Content)
        {
            S7Client.Write("DB4.DBX4.2", true); // 开始复位
            while (!S7Client.ReadBool("DB4.DBX86.1").Content) //检测复位是否完成
            {
                Thread.Sleep(1000);
            }
            S7Client.Write("DB4.DBX4.2", false); // 停止复位
        }

        if (!S7Client.ReadBool("DB4.DBX4.0").Content)
        {
            S7Client.Write("DB4.DBX4.0", true); // 开始运行 
        }

        return Ok();
    }
    
    [Route("stop")]
    [HttpPost]
    public ActionResult Stop()
    {
        S7Client.Write("DB4.DBX4.0", false); // 停止运行
        return Ok();
    }

    static private readonly Random r = new Random();
    [HttpGet]
    public PlcState Get()
    {
        PlcState state = new PlcState();
        state.stopped = S7Client.ReadBool("DB4.DBX6.0").Content;
        state.x = S7Client.ReadFloat("MD504").Content;
        state.z = S7Client.ReadFloat("MD516").Content;
        state.weights = new float[4]
        {
            S7Client.ReadFloat("DB4.DBD48").Content,
            S7Client.ReadFloat("DB4.DBD52").Content,
            S7Client.ReadFloat("DB4.DBD56").Content,
            S7Client.ReadFloat("DB4.DBD60").Content
        };
        return state;
    }
}

public class PlcState
{
    public bool stopped { get; set; }
    public float x { get; set; }
    public float z { get; set; }
    public float[] weights { get; set; }
}

public class StartParameter
{
    public float a, b, c, d;
}