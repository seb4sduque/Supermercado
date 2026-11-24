namespace Front_Supermercado.Nucleo
{

    public static class Permisos
    {
        public const string Administrador = "Administrador";
        public const string Empleado = "Empleado";

        private static readonly Dictionary<string, (string Contraseña, string Rol)> Usuarios =
            new(StringComparer.Ordinal)
            {
                ["Usuario"] = ("123", Administrador),
                ["Usuario2"] = ("1234", Empleado),
            };

        private static readonly Dictionary<string, HashSet<string>?> VentanasPorRol =
            new(StringComparer.OrdinalIgnoreCase)
            {
                [Administrador] = null,
                [Empleado] = new(StringComparer.OrdinalIgnoreCase)
                {
                    "Clientes", "Productos", "Inventarios", "MetodosPago",
                    "Facturas", "DetallesFacturas",
                },
            };

        // Ventanas de venta: las crea el Empleado. Modificar y borrar es solo del Administrador.
        // En las demás ventanas el Administrador crea, modifica y borra.
        private static readonly HashSet<string> Ventas =
            new(StringComparer.OrdinalIgnoreCase) { "Facturas", "DetallesFacturas" };

        public static string? Validar(string? usuario, string? contraseña)
        {
            if (usuario == null || contraseña == null) return null;
            if (Usuarios.TryGetValue(usuario, out var u) && u.Contraseña == contraseña)
                return u.Rol;
            return null;
        }

        public static bool PuedeVer(string? rol, string ventana)
        {
            if (string.IsNullOrEmpty(rol)) return false;
            if (!VentanasPorRol.TryGetValue(rol, out var permitidas)) return false;
            return permitidas == null || permitidas.Contains(ventana);
        }

        // Crear: en las ventas solo el Empleado; en las demás ventanas solo el Administrador
        public static bool PuedeCrear(string? rol, string ventana)
        {
            if (!PuedeVer(rol, ventana)) return false;
            return Ventas.Contains(ventana) ? rol == Empleado : rol == Administrador;
        }

        public static bool PuedeCrear(HttpContext contexto, string ventana)
            => PuedeCrear(contexto.Session.GetString("Rol"), ventana);

        // Modificar (corregir): siempre solo el Administrador
        public static bool PuedeModificar(string? rol, string ventana)
            => PuedeVer(rol, ventana) && rol == Administrador;

        public static bool PuedeModificar(HttpContext contexto, string ventana)
            => PuedeModificar(contexto.Session.GetString("Rol"), ventana);

        public static bool PuedeBorrar(HttpContext contexto)
            => contexto.Session.GetString("Rol") == Administrador;

        public static string MensajeEditar(string ventana, string accion)
        {
            if (Ventas.Contains(ventana))
                return accion == "crear"
                    ? "Solo un empleado puede crear ventas (facturas y sus detalles)."
                    : "Solo el administrador puede modificar ventas (facturas y sus detalles).";
            return "Solo el administrador puede crear o modificar registros en esta ventana.";
        }

        public static string MensajeBorrar()
            => "Solo el administrador puede borrar registros.";

        public static bool PuedeVerAlguna(HttpContext contexto, params string[] ventanas)
            => ventanas.Any(v => PuedeVer(contexto, v));

        public static bool PuedeVer(HttpContext contexto, string ventana)
            => PuedeVer(contexto.Session.GetString("Rol"), ventana);
    }
}
