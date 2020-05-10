using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Cliente
    {
        [Key]
        [StringLength(20)]
        public string Identificacion { get; set; }
        [StringLength(13)]
        public string Nombre { get; set; }
        public decimal CapitalInicial { get; set; }
        public double Interes { get; set; }
        public int Tiempo { get; set; }
        public decimal TotalAPagar { get; set; }

        public void CalcularTotalAPagar(){
            TotalAPagar = CapitalInicial * (decimal)Math.Pow((1 + CalcularInteres(Interes)),Tiempo);
        }

        private double CalcularInteres(double interes){
            Interes = (interes / 100);
            return Interes;
        }
    }
}
