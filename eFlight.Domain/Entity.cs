using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectsPortifolio.Domain
{
    public abstract class Entity
    {
        public virtual int Id { get; set; }

        public void SetId()
        {
            Random random = new Random();
            Id = random.Next();
        }
    }
}