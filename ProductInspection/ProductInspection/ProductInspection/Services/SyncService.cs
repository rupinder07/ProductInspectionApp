using Newtonsoft.Json;
using Plugin.Connectivity;
using ProductInspection.Model;
using ProductInspection.repository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductInspection.Services
{
    class SyncService
    {

        private static Queue<Event> EventQueue = new Queue<Event>();

        internal async static void PushAsync(Event currentEvent)
        {
            if (await IsBackendReachable())
            {
                //If there is any pending event, push it downwards
                while(EventQueue.Count > 0)
                {
                    Event QueuedEvent = EventQueue.Dequeue();
                    try
                    {
                        await RestClient.PerformOperation(QueuedEvent);
                        new BaseRepository<Product>().DeleteItemById(QueuedEvent.TableName, QueuedEvent.Id);
                    }
                    catch(Exception e)
                    {
                        Console.Out.Write(e);
                    }

                }

                //Perform current event
                await RestClient.PerformOperation(currentEvent);
            }
            else
            {
                //Enqueue the event
                EventQueue.Enqueue(currentEvent);
                new BaseRepository<Product>().SaveItemAsync(currentEvent.Entity as Product);
            }
        }

        public async static Task<bool> IsBackendReachable()
        {
            return await CrossConnectivity.Current.IsRemoteReachable(RestClient.HOSTNAME,
                RestClient.port,
                1000);
        }
    }
}
