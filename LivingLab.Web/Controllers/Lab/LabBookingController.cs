using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels.Booking;
using LivingLab.Web.UIServices.LabBooking;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Lab;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabBookingController: Controller
{
    private readonly ILabBookingService _labBookingService;
    
    private readonly ILogger<LabBookingController> _logger;

    private readonly UserManager<ApplicationUser> _usermanager;

    public LabBookingController(UserManager<ApplicationUser> usermanager, ILabBookingService labBookingService, ILogger<LabBookingController> logger)
    {
        _labBookingService = labBookingService;
       
        _logger = logger;

        _usermanager = usermanager;
         //Initalise labBooking service and usermanager which is used to get userid 

    }
    [Authorize]
    /*User can see this page and register a new Booking*/
     //Function which navigate to a book register form  page named Register with a preset value labid. 
         public IActionResult Register(int labid = 0)
    {  
        BookFormModel newForm = new BookFormModel() {LabId = labid};
        
        return View("Register", newForm);
    }

    /*Everyone can see this page and delete exist Booking*/
    [Authorize(Roles = "User,Admin,Labtech")]
      /*User,Admin and Labtech can see this Booking overview page */
    [HttpGet]
    public async Task<IActionResult> BookingsOverview(BookingManagementViewModel listOfBookings)
    {    
         var getList = await _labBookingService.RetrieveList();
         //getting the lab data from lab table in database as a list from labBookingservice 
         listOfBookings.list = getList;
         //store the list in a variable of BookingManagementViewModel
         return View("Index", listOfBookings);
    }
    
    /*User,Admin and Labtech can see this ViewAllBooking page which display the existed booking */
    [Authorize(Roles = "User,Admin,Labtech")]
    [HttpGet]
    public async Task<IActionResult> ViewAllBookings(BookingTableManagementViewModel listOfBookings)
    {
         var getList = await _labBookingService.RetrieveBookTableList();
            //getting the book data from Booking table in database as a list from labBookingservice 
         listOfBookings.list = getList;
         //store the list in a variable of BookingManagementViewModel
         _logger.LogInformation(listOfBookings.ToString());
         
        return View("ViewBooking", listOfBookings);
    }

   
   /*Everyone can register a new booking*/
    [Authorize(Roles = "User,Admin,Labtech")]
    [HttpPost]
       public async Task<IActionResult> BookRegister(BookFormModel labModel)
    {    
        var user = await _usermanager.GetUserAsync(User);
        // get current user id from usermanager
            await _labBookingService.CreateBook(labModel, user.Id);
            // Call LabBookingservice function to create a book data in database
            return View("_CompleteBooking");
    }

        /*User can delete lab booking*/
       [Route("deletebooking/{bookingid}")]
         public async Task<IActionResult> DeleteBook(BookingTableManagementViewModel listOfBookings, int bookingid)
    {       
        await _labBookingService.DeleteBook(bookingid);
        // call LabBookingservice to delete a row of book data with the same booking id as input of the function. 


        var getList = await _labBookingService.RetrieveBookTableList();
        listOfBookings.list = getList;
        //navigate back to ViewBooking page after deletion is done. 
        return View("ViewBooking", listOfBookings);
    }
    
}
