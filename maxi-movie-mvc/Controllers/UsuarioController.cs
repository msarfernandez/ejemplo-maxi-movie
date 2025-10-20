using maxi_movie_mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace maxi_movie_mvc.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        public UsuarioController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel usuario)
        {
            if(ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Clave, usuario.Recordarme, lockoutOnFailure: false);
                if(resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Inicio de sesión inválido.");
                }
            }
            return View(usuario);
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(RegistroViewModel usuario)
        {
            if(ModelState.IsValid)
            {
                // Lógica para registrar al usuario
                var nuevoUsuario = new Usuario
                {
                    UserName = usuario.Email,
                    Email = usuario.Email,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    ImagenUrlPerfil = "default-profile.png"
                };
                var resultado = await _userManager.CreateAsync(nuevoUsuario, usuario.Clave);
                if(resultado.Succeeded)
                {
                    await _signInManager.SignInAsync(nuevoUsuario, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in resultado.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }


            }
            return View(usuario);
        }

        public IActionResult Logout() {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }



    }
}
