namespace Tarea1_PruebaDeConcepto.Modelos
{
    public class Empleado
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public double Salario { get; set; }

        public Empleado(int id, string Nombre, double Salario)
        {
            this.id = id;
            this.Nombre = Nombre;
            this.Salario = Salario;
        }
    }
}
