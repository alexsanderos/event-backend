using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Core;

namespace Event.Domain.Interfaces
{
    public interface INotification
    {
        List<DomainNotifications> GetNotifications();
        void AddNotification(DomainNotifications message);
        bool HasNotifications();
    }
}
