using RecipeBox.Models;
using RecipeBox.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace RecipeBox.Controllers
{
  public class AdminController : Controller
  {
    private UserManager<ApplicationUser> _userManager;
    // private IPasswordHasher<ApplicationUser> passwordHasher;

    public AdminController(UserManager<ApplicationUser> usrMgr)
    {
      _userManager = usrMgr;
      // passwordHasher = passwordHash;
    }

    public IActionResult Index()
    {
      return View(_userManager.Users);
    }

    public ViewResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(RegisterViewModel user)
    {
      if (ModelState.IsValid)
      {
        ApplicationUser appUser = new ApplicationUser
        {
          UserName = user.Email,
          FirstName = user.FirstName,
          Email = user.Email
        };

        IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);

        if (result.Succeeded)
          return RedirectToAction("Index");
        else
        {
          foreach (IdentityError error in result.Errors)
            ModelState.AddModelError("", error.Description);
        }
      }
      return View(user);
    }

    public async Task<IActionResult> Update(string id)
{
    ApplicationUser userToUpdate = await _userManager.FindByIdAsync(id);
    var viewModel = new RegisterViewModel 
    {
        FirstName = userToUpdate.FirstName,
        Email = userToUpdate.Email
    };
    return View(viewModel); 
}   

    [HttpPost]
public async Task<IActionResult> Update(string id, RegisterViewModel viewModel)
{
    ApplicationUser user = await _userManager.FindByIdAsync(id);
    if (user != null)
    {
        if (!string.IsNullOrEmpty(viewModel.Email))
            user.Email = viewModel.Email;
        else
            ModelState.AddModelError("", "Email cannot be empty");

        // // if (!string.IsNullOrEmpty(viewModel.Password))
        // //     user.PasswordHash = passwordHasher.HashPassword(user, viewModel.Password);
        // // else
        //     ModelState.AddModelError("", "Password cannot be empty");

        if (!string.IsNullOrEmpty(viewModel.Email) && !string.IsNullOrEmpty(viewModel.Password))
        {
            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return RedirectToAction("Index");
            else
                Errors(result);
        }
    }
    else
        ModelState.AddModelError("", "User Not Found");

    return View(viewModel);
}

    private void Errors(IdentityResult result)
    {
      foreach (IdentityError error in result.Errors)
        ModelState.AddModelError("", error.Description);
    }
  }
}