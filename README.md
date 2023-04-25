# Wake on LAN 

Simple wake-on-LAN CLI tool. Broadcasts a "magic packet" in the local network that turns on (or awakens) a computer in 
the network. As the NIC (network interface card) only looks for the magic packet this can be achieved over any network
protocol, this tool sends a UDP broadcast on port 0. Also there is no confirmation of delivery or if the target computer
has been successfully turned on.

The payload consists of 6 bytes of 1s followed by 16 repetitions of the target computer's MAC address. 

## Setting up

1. Make sure you have hardware support for WOL on the target computer.
2. Enable WOL and find the physical (MAC) address of the NIC

## Usage

```
WakeOnLan -a/--address <MAC-address>
```

## References

https://en.wikipedia.org/wiki/Wake-on-LAN

## License

Distributed under [MIT License](./LICENSE).