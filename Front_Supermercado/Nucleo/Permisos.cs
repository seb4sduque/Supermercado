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
                    "Clientes",
                    "Categorias", "Subcategorias", "Productos",
                    "Inventarios",
                    "Facturas", "DetallesFacturas", "MetodosPago",
                },
            };

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

        public static bool PuedeVerAlguna(HttpContext contexto, params string[] ventanas)
            => ventanas.Any(v => PuedeVer(contexto, v));

        public static bool PuedeVer(HttpContext contexto, string ventana)
            => PuedeVer(contexto.Session.GetString("Rol"), ventana);
    }
}
