using System;
using System.Collections.Generic;

namespace EmployeeDemoApp.Models
{
    public class UserPosition
    {
        public Guid EmployeeId { get; set; }
        public Guid PositionId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Position Position { get; set; }

        public UserPosition(Guid employeeId, Guid positionId)
        {
            EmployeeId = employeeId;
            PositionId = positionId;
        }
    }
}
