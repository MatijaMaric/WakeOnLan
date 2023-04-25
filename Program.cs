using System.CommandLine;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

var addressOption = new Option<string>(
    name: "--address",
    description: "Physical (MAC) address of computer to wake up"
);
addressOption.AddAlias("-a");
addressOption.IsRequired = true;

var rootCommand = new RootCommand("Wake on LAN tool");
rootCommand.AddOption(addressOption);

rootCommand.SetHandler(HandleWOL, addressOption);

return await rootCommand.InvokeAsync(args);

void HandleWOL(string addressRaw)
{
    var address = PhysicalAddress.Parse(addressRaw);
    var addressBytes = address.GetAddressBytes();

    using var ms = new MemoryStream();
    using var bw = new BinaryWriter(ms);

    for (var i = 0; i < 6; ++i)
    {
        bw.Write((byte)0xff);
    }

    for (var i = 0; i < 16; ++i)
    {
        bw.Write(addressBytes);
    }

    var packet = ms.ToArray();

    var client = new UdpClient();
    client.Connect(IPAddress.Broadcast, 0);

    client.Send(packet);
}