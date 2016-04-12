using System;
using System.Collections.Generic;

namespace GamaAfterTheHolyGrail.Business
{
    public class Proyecto : TimestampedPOCO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Seguimiento { get; set; }

        public DateTime? FechaDeInicio { get; set; }
        public DateTime? FechaDeFinalizacion { get; set;}

        public EstadoDeProyecto Estado { get; set; }
        public List<Objetivo> Objetivos { get; set; }
        public List<Colaborador> Colaboradores { get; set; }
        public List<Evento> Eventos { get; set; }

        public string TagsAsString { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
