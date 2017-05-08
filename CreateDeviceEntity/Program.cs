﻿using Microsoft.Azure.Devices;

using Microsoft.Azure.Devices.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDeviceEntity
{
    class Program
    {
        static RegistryManager registryManager;
        static string connectionString = "HostName=TIKOIOTHolmstrom.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=mBg2wDr9LWggfoKSGSnYaCGAnaeES9qLS8S37GgccVc=";

        private static async Task AddDeviceAsync()
        {
            string deviceId = "myFirstDevice";
            Device device;
            try
            {
                device = await registryManager.AddDeviceAsync(new Device(deviceId));
            }
            catch (DeviceAlreadyExistsException)
            {
                device = await registryManager.GetDeviceAsync(deviceId);
            }
            Console.WriteLine("Generated device key: {0}", device.Authentication.SymmetricKey.PrimaryKey);
        }


        static void Main(string[] args)
        {
            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
            AddDeviceAsync().Wait();
            Console.ReadLine();
        }
    }
}
