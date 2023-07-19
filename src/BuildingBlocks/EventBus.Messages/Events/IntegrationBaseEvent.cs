using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class IntegrationBaseEvent
    {
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }

        public IntegrationBaseEvent()
        {
            Id = Guid.NewGuid();
            CreationTime = DateTime.Now;
        }

        public IntegrationBaseEvent(Guid id, DateTime creationTime)
        {
            Id = id;
            CreationTime = creationTime;
        }
    }
}
