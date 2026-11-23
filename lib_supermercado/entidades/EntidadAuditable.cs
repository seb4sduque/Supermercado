namespace lib_supermercado.entidades
{
    // Clase base: todas las entidades heredan estos campos de auditoría
    public abstract class EntidadAuditable
    {
        public DateTime FechaCreacion { get; set; }
        public string? CreadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? ModificadoPor { get; set; }
    }
}
