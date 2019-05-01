using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Event.Domain.Core;
using Event.Domain.Interfaces;

namespace Event.Domain.Notification
{
    public class Notification : INotification
    {
        private List<DomainNotifications> _notifications;

        public Notification()
        {
            _notifications = new List<DomainNotifications>();
        }

        public virtual List<DomainNotifications> GetNotifications()
        {
            return _notifications;
        }

        public void AddNotification(DomainNotifications message)
        {
            _notifications.Add(message);
        }

        public virtual bool HasNotifications()
        {
            return _notifications.Any();
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotifications>();
        }
    }
}
