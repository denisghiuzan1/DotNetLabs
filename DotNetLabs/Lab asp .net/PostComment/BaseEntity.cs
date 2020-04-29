using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PostComment
{
    public enum State
    {
        Added,
        Unchanged,
        Modified,
        Deleted
    }
    [DataContract(IsReference = true)]
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            State = State.Unchanged;
        }
        [DataMember]
        public State State { get; set; }
    }
    public static class EntityConvertState
    {
        public static EntityState ConvertState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;
                case State.Modified:
                    return EntityState.Modified;
                case State.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
    }

}
