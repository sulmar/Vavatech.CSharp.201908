using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.TrackingSystem.Models
{

    public abstract class Base
    {

    }

    public abstract class BaseEntity : Base
    {
        public int Id { get; set; }
    }
}
