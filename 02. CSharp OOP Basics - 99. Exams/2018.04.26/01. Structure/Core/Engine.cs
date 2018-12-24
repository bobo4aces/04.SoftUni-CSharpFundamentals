using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace StorageMaster.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            StorageMaster storageMaster = new StorageMaster();
            while (command[0]?.ToLower() != "end")
            {
                try
                {
                    string type = string.Empty;
                    double price = 0;
                    string name = string.Empty;
                    string storageName = string.Empty;
                    int garageSlot = 0;
                    string sourceName = string.Empty;
                    int sourceGarageSlot = 0;
                    string destinationName = string.Empty;

                    switch (command[0].ToLower())
                    {
                        case "addproduct":
                            type = command[1];
                            price = double.Parse(command[2]);
                            string addedProduct = storageMaster.AddProduct(type, price);
                            Console.WriteLine(addedProduct);
                            break;
                        case "registerstorage":
                            type = command[1];
                            name = command[2];
                            string registeredStorage = storageMaster.RegisterStorage(type, name);
                            Console.WriteLine(registeredStorage);
                            break;
                        case "selectvehicle":
                            storageName = command[1];
                            garageSlot = int.Parse(command[2]);
                            string selectedVehicle = storageMaster.SelectVehicle(storageName, garageSlot);
                            Console.WriteLine(selectedVehicle);
                            break;
                        case "loadvehicle":
                            List<string> productNames = new List<string>();
                            for (int i = 1; i < command.Length; i++)
                            {
                                productNames.Add(command[i]);
                            }
                            string loadedVehicle = storageMaster.LoadVehicle(productNames);
                            Console.WriteLine(loadedVehicle);
                            break;
                        case "sendvehicleto":
                            sourceName = command[1];
                            sourceGarageSlot = int.Parse(command[2]);
                            destinationName = command[3];
                            string sendVehicle = storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                            Console.WriteLine(sendVehicle);
                            break;
                        case "unloadvehicle":
                            storageName = command[1];
                            garageSlot = int.Parse(command[2]);
                            string unloadedVehicle = storageMaster.UnloadVehicle(storageName, garageSlot);
                            Console.WriteLine(unloadedVehicle);
                            break;
                        case "getstoragestatus":
                            storageName = command[1];
                            string storageStatus = storageMaster.GetStorageStatus(storageName);
                            Console.WriteLine(storageStatus);
                            break;
                        default:
                            break;

                    }

                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
                command = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
            }
            Console.WriteLine(storageMaster.GetSummary());
        }
    }
}
