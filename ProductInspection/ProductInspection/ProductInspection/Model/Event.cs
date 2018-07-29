using ProductInspection.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInspection.Model
{
    class Event
    {

        public int Id { get; set; }

        public IBaseEntity Entity { get; set; }

        public HttpOperation Operation { get; set; }

        public String URI { get; set; }

        public String TableName { get; set; }
    }
}
