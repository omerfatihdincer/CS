using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Core.Entities
{
    public abstract class FullAuditedEntity
    {
        //
        // Summary:
        //     Creation time of this entity.
        public virtual DateTime CreationTime { get; set; }
        //
        // Summary:
        //     The last modified time for this entity.
        public virtual DateTime? LastModificationTime { get; set; }
        //
        // Summary:
        //     Is this entity Deleted?
        public virtual bool IsDeleted { get; set; }
        //
        // Summary:
        //     Deletion time of this entity.
        public virtual DateTime? DeletionTime { get; set; }
    }
}
