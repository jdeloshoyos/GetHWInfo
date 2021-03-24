using System;
using Hardware.Info;

namespace GetHWInfo
{
    class Program
    {
        static readonly HardwareInfo hardwareInfo = new HardwareInfo();

        static void Main(string[] args)
        {
            Console.WriteLine("TEST - Get Hardware Info con .NET CORE");
            Console.WriteLine("Usando librería Hardware.Info\n");

            // Guía de la librería: https://github.com/Jinjinov/Hardware.Info
            
            // Refrescamos toda la info disponible
            hardwareInfo.RefreshAll();

            ImprimeHeader("CPU");
            foreach (var hardware in hardwareInfo.CpuList)
                Console.WriteLine(hardware);

            ImprimeHeader("Discos");
            foreach (var drive in hardwareInfo.DriveList)
            {
                Console.WriteLine(drive);

                foreach (var partition in drive.PartitionList)
                {
                    Console.WriteLine(partition);

                    foreach (var volume in partition.VolumeList)
                        Console.WriteLine(volume);
                }
            }

            ImprimeHeader("Memoria");
            foreach (var hardware in hardwareInfo.MemoryList)
                Console.WriteLine(hardware);

            ImprimeHeader("Monitores");
            foreach (var hardware in hardwareInfo.MonitorList)
                Console.WriteLine(hardware);

            ImprimeHeader("Adaptador de video");
            foreach (var hardware in hardwareInfo.VideoControllerList)
                Console.WriteLine(hardware);

        }

        private static void ImprimeHeader(string texto)
        {
            Console.WriteLine(texto);
            Console.WriteLine(new String('-', texto.Length));
            Console.WriteLine();
        }
    }
}
