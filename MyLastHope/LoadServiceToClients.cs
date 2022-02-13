using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLastHope
{
    class LoadServiceToClients
    {
        int selectedClient = 0, idService;
        Services service;
        List<Clients> clients = BaseConnect.BaseModel.Clients.ToList();
        List<string> clientsNames = new List<string>();
        DateTime dateTimeBegin = DateTime.Today;
        DateTime timeBegin = new DateTime();
        public string Title => service.Title;
        public string Duration => service.DurationInMinute.ToString() + " мин.";
        public List<string> Clients => clientsNames;
        public int ClientIndex { get => selectedClient; set => selectedClient = value; }
        public DateTime DateBegin { get => dateTimeBegin; set => dateTimeBegin = value; }
        public DateTime TimeBegin { get => timeBegin; set => timeBegin = value; }
        public LoadServiceToClients(int idService)
        {
            this.idService = idService;
            service = BaseConnect.BaseModel.Services.FirstOrDefault(x => x.ID_service == idService);
            foreach (var client in clients)
            {
                clientsNames.Add(client.Lastname + " " + client.Name + " " + client.Pantonymic);
            }            
        }
        public bool SaveData()
        {
            if (selectedClient != -1)
            {
                int lastId = BaseConnect.BaseModel.ServiceToClients.ToList().Last().ID_serviceclient + 1;
                List<string> namesClient = clientsNames[selectedClient].Split(' ').ToList();
                int idClient = clients.FirstOrDefault(x => x.Lastname == namesClient[0] && x.Name == namesClient[1] && x.Pantonymic == namesClient[2]).ID_client;
                dateTimeBegin.AddHours(timeBegin.Hour);
                dateTimeBegin.AddMinutes(timeBegin.Minute);
                BaseConnect.BaseModel.ServiceToClients.Add(new ServiceToClients() 
                { ID_serviceclient = lastId, 
                  ID_client =  idClient,
                  ID_service = idService,
                  BeginningDate = dateTimeBegin
                });
                BaseConnect.BaseModel.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
