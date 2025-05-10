using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace User.Clients
{
    public class ClientManager
    {
        private List<Client> _activeClients = new ();

        public void AddActiveClient(Client client)
        {
            Debug.Log("Active client registered");
            _activeClients.Add(client);
        }

        public void RemoveActiveClient(Client client)
        {
            Debug.Log("Client disconnected");
            _activeClients.Remove(client);
        }

        public Client GetActiveClient(int clientId)
        {
            return _activeClients.FirstOrDefault(client => client.UserId == clientId);
        }
    }
}
