﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Application.DTOs.Screening.Responce
{
    public class ScreeningGetByDateAndAuditoriumIdResponce : BaseScreeningDto
    {
        public Guid Id { get; set; }
    }
}