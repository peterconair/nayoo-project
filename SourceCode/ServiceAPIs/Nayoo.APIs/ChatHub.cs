using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nayoo.APIs
{
    public class ChatHub : Hub
    {
        #region Data Members

        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();

        #endregion

        #region Methods

        public void Connect(string userName, string companyCode)
        {
            var id = Context.ConnectionId;


            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName, CompanyCode = companyCode });

                // send to caller
                Clients.Caller.onConnected(id, userName, companyCode, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, userName, companyCode);

            }

        }

        public void SendMessageToAll(string userName, string companyCode, string message)
        {
            // store last 100 messages in cache
            AddMessageinCache(userName, companyCode, message);

            // Broad cast message
            Clients.All.messageReceived(userName, companyCode, message);
        }

        public void SendMessageToStatus(string userName, string message)
        {
            // store last 100 messages in cache
            //AddMessageinCache(userName, message);

            // Broad cast message
            Clients.All.statusReceived(ConnectedUsers, userName, message);
        }

        public void SendPrivateMessage(string toUserId, string message)
        {

            string fromUserId = Context.ConnectionId;

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            if (toUser != null && fromUser != null)
            {
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
            }

        }

        public override System.Threading.Tasks.Task OnDisconnected(bool StopCalled)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName, item.CompanyCode);

            }

            return base.OnDisconnected(true);
        }

        #endregion

        #region private Messages

        private void AddMessageinCache(string userName, string companycode, string message)
        {
            CurrentMessage.Add(new MessageDetail { UserName = userName, CompanyCode = companycode, Message = message });

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);
        }

        #endregion
    }

    public class UserDetail
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
        public string CompanyCode { get; set; }
    }

    public class MessageDetail
    {
        public string CompanyCode { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }

    }
}