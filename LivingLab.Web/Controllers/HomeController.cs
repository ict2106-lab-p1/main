using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels.LivingLabDashboard;
using LivingLab.Web.UIServices.LabProfile;
using LivingLab.Web.UIServices.LivingLabDashboard;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ILabProfileService _labProfileService;
    private readonly ILivingLabDashboardService _dashboardService;


    public HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager, ILabProfileService labProfileService, ILivingLabDashboardService dashboardService)
    {
        _logger = logger;
        _signInManager = signInManager;
        _labProfileService = labProfileService;
        _dashboardService = dashboardService;
    }

    /*Reroute the users to the login page*/
    [AllowAnonymous]
    [Route("/")]
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Login");
    }

    /*Reroute the users to the main dashboard*/
    [Authorize(Roles = "User,Labtech,Admin")]
    public async Task<IActionResult> Dashboard()
    {
        LivingLabDashboardViewModel viewLabs = await _dashboardService.GetAllLabs();
        return View("Dashboard", viewLabs);
    }

    /*Privacy page which was built in*/
    [Authorize(Roles = "Admin")]
    public IActionResult Privacy()
    {
        return View("Privacy");
    }
    
    /*Can be called to remove the user*/
    [Authorize(Roles = "User,Labtech,Admin")]
    public IActionResult Logout()
    {
        _logger.LogInformation("Logging out");
        //Delete the Session object.
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        _signInManager.SignOutAsync();
        HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
        return RedirectToAction("Index", "Login");
    }

    [AllowAnonymous]
    /*Simple access denied page*/
    public IActionResult AccessDenied()
    {
        return View("_AccessDenied");
    }
    
    /*Navigation bar population of data information*/
    public async Task<IActionResult> GetLabs()
    {
        /*var renderList = "";*/
        var listOfLabs = await _labProfileService.GetAllLabAccounts();
        /*foreach (var lab in listOfLabs)
        {
            renderList += "<li><a class=\"@Html.ActiveClass(\"LabBooking\", \"BookingsOverview\") hover:translate-x-2 transition-transform ease-in duration-300 w-full flex items-center h-10 pl-4 cursor-pointer\"asp-controller=\"LabProfile\" asp-action=\"LabProfile\" asp-route-labLocation=\""+lab.LabLocation+"\"><span>"+lab.LabLocation+"</span></a></li>";
        }*/
        //query database, and get the data.
        return Json(listOfLabs);
    }

    /*Not in use, just an example*/
    [Route("/example")]
    public IActionResult ExamplePage()
    {
        return View("ExamplePage");
    }

}
