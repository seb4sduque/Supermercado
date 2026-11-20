using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Supermercado.interfaces
{
    public interface IDetallesFacturasPresentacion
    {
        DetallesFacturas Insertar(DetallesFacturas entidad);
        List<DetallesFacturas> Consultar();
        DetallesFacturas Actualizar(DetallesFacturas entidad);
        DetallesFacturas Borrar(DetallesFacturas entidad);
    }
}
