﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Domain.Entities
{
    public class Auditorium : BaseEntity
    {
        public int Capacity { get; set; }
        public string Name { get; set; }
        public ICollection<Seats> Seats { get; set; }

    }
}
