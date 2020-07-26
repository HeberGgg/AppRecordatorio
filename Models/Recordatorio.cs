
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Recordatorio
    {
          [Key]
          public int ID { get; set;}
          public string NombreCliente { get; set; }
          public string Telefono {get; set;}
          public string Correo {get; set;}
          public DateTime FechaRecordatorio {get; set;}
          public DateTime HoraRecordatorio {get; set;}
          public string Titulo {get; set;}
          public string Descripcion {get; set;}
      
    }
}