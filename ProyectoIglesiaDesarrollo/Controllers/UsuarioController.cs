using Mapster;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoIglesiaDesarrollo.Models;
using ProyectoIglesiaDesarrollo.Models.Domain;
using ProyectoIglesiaDesarrollo.Models.Domain.Entidades;
using System.Security.Cryptography;
using System.Text;

namespace ProyectoIglesiaDesarrollo.Controllers
{
    public class UsuarioController : Controller
    {
        private IglesiaDbContext _context;
        public UsuarioController(IglesiaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string Codigo)
        {
            if (!string.IsNullOrWhiteSpace(Codigo))
            {
                ViewBag.Error = "Su Sesion Expiro";
                return View(new UsuarioVm());
            }
            HttpContext.Session.Clear();
            return View(new UsuarioVm());
        }
        [HttpPost]
        public IActionResult Index(UsuarioVm vm)
        {
            var user = _context.Usuario
                               .Where(w => w.Email == vm.Email)
                               .ProjectToType<UsuarioVm>()
                               .FirstOrDefault();
            if (user == null)
            {
                ViewBag.Error = "Usuario o la contraseña no existen";
                ViewBag.ClaseMensaje = "alert alert-warning alert-dismissable";
                return View(new UsuarioVm());
            }
            if (user.Password != GetMD5(vm.Password))
            {
                ViewBag.Error = "Usuario o la contraseña no existen";
                ViewBag.ClaseMensaje = "alert alert-warning alert-dismissable";
                return View(new UsuarioVm());
            }

            var modulosroles = _context.ModulosRoles
                                       .Where(w => w.Eliminado == false && w.RolId == user.Rol.Id)
                                       .ProjectToType<ModulosRolesVm>()
                                       .ToList();

            var agrupadosid = modulosroles.Select(s => s.Modulo.AgrupadoModuloId).Distinct().ToList();
            var agrupados = _context.AgrupadoModulos
                                    .Where(w => agrupadosid.Contains(w.Id))
                                    .ProjectToType<AgrupadoVm>()
                                    .ToList();

            foreach (var item in agrupados)
            {
                var modulosactuales = modulosroles
                                      .Where(w => w.Modulo.AgrupadoModuloId == item.Id)
                                      .Select(s => s.Modulo.Id)
                                      .Distinct()
                                      .ToList();
                item.Modulos = item.Modulos.Where(w => modulosactuales.Contains(w.Id)).ToList();
            }

            user.Menu = agrupados;
            user.Password = string.Empty;

            var sesionjson = JsonConvert.SerializeObject(user);
            var plainTextBytes = Encoding.UTF8.GetBytes(sesionjson);
            var sesionbase64 = Convert.ToBase64String(plainTextBytes);
            HttpContext.Session.SetString("UsuarioObjeto", sesionbase64);

            return View();
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}