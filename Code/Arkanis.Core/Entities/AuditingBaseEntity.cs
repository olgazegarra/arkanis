using System;
namespace Arkanis.Core.Entities
{
    public class AuditingBaseEntity
    {
		public string createdBy { get; set; }
		public DateTime createdOn { get; set; }

		public string updatedBy { get; set; }
		public DateTime updatedOn { get; set; }

		public AuditingBaseEntity() {
            this.createdOn = DateTime.UtcNow;
        }
    }
}
