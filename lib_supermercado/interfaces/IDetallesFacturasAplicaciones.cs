using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.interfaces
{
    public interface IDetallesFacturasAplicaciones
    {
        DetallesFacturas Insertar(DetallesFacturas entidad);
        List<DetallesFacturas> Consultar();
        DetallesFacturas Actualizar(DetallesFacturas entidad);
        DetallesFacturas Borrar(DetallesFacturas entidad);
    }
}
