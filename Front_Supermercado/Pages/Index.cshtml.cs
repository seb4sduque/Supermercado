using Front_Supermercado.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Supermercado.Pages
{
    public class IndexModel : PageModel
    {
        public bool EstaLogueado = false;
        public string? Mensaje { get; set; }
        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Contraseña { get; set; }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contraseña = string.Empty;
            }
            catch (Exception ex)
            {
                Mensaje = ex.GetBaseException().Message;
            }
        }

        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Email) &&
                    string.IsNullOrEmpty(Contraseña))
                {
                    OnPostBtClean();
                    return;
                }

                var rol = Permisos.Validar(Email, Contraseña);
                if (rol == null)
                {
                    OnPostBtClean();
                    Mensaje = "Usuario o contraseña incorrectos.";
                    return;
                }

                HttpContext.Session.SetString("Usuario", Email!);
                HttpContext.Session.SetString("Rol", rol);
                EstaLogueado = true;
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                Mensaje = ex.GetBaseException().Message;
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                Mensaje = ex.GetBaseException().Message;
            }
        }
    }
}
