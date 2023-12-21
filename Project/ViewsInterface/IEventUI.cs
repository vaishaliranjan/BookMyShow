using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewsInterface
{
    public interface IEventUI
    {
        void ViewEvents();
        void CreateEvent(string organizerUsername);
        void CancelEvent();
    }
}
