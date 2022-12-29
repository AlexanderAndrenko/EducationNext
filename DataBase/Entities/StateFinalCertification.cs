﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class StateFinalCertification
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float QuantityCreditUnit { get; set; }
        public List<EducationalStandartStateFinalCertification>? EducationalStandartStateFinalCertifications { get; set; }
        public List<SyllabusStateFinalCertification>? SyllabusStateFinalCertifications { get; set; }
    }
}