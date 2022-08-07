using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDemoApp.Models
{
    public class UserPosition
    {
        [ConcurrencyCheck]
        public Guid EmployeeId { get; set; }
        public Guid PositionId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Position Position { get; set; }

        public UserPosition(Guid employeeId, Guid positionId)
        {
            EmployeeId = employeeId;
            PositionId = positionId;
        }
    }
}
