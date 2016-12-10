using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ExamSkillProject.Models
{
    public class MyHub : Hub
    {
        public void Hello(string name, string text)
        {
            Clients.All.newMessage(name, text);
          
        }
    }
}