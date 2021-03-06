﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{

    class Program
    {
        static void Main(string[] args)
        {
            Program application = new Program();
            application.startServer();

        }

        public void startServer()
        {
            EasyModbus.ModbusServer modbusServer = new EasyModbus.ModbusServer();
            modbusServer.SerialPort = "COM3";
            modbusServer.UnitIdentifier = 1;
            modbusServer.Baudrate = 9600;
            
            modbusServer.Listen();
            modbusServer.holdingRegistersChanged += new EasyModbus.ModbusServer.HoldingRegistersChanged(holdingRegistersChanged);
            Console.ReadKey();
            modbusServer.StopListening();
        }

        public void holdingRegistersChanged(int startingAddress, int quantity)
        {
            Console.WriteLine(startingAddress);
            Console.WriteLine(quantity);
        }
    }
}
