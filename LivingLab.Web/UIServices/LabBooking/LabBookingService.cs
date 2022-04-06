using AutoMapper;

using LivingLab.Core.DomainServices.Lab;
using LivingLab.Core.Entities;
using LivingLab.Web.Models.ViewModels.Booking;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.UIServices.LabProfile;

namespace LivingLab.Web.UIServices.LabBooking;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabBookingService : ILabBookingService
{
    private readonly  IMapper _mapper;
    private readonly ILabProfileDomainService _labProfileDomainService;
    private readonly IBookingDomainService _BookingDomainService;

    public LabBookingService(IMapper mapper, ILabProfileDomainService labProfileDomainService,IBookingDomainService BookingDomainService)
    {
        _mapper = mapper;
        _labProfileDomainService = labProfileDomainService;
        _BookingDomainService=BookingDomainService;
        //initial mapper, Labdomainservice and bookingdomainservice
    }


    public async Task<List<BookingTableViewModel>> RetrieveBookTableList()
    {
                var listOfBooks = await _BookingDomainService.ViewBooks();
                //Store the book data list in the variable listofbook .
                List<BookingTableViewModel> listOfBooking = new List<BookingTableViewModel>();
                //Create list of BookingTableViewModel object to store the data
                 foreach (Booking Book in listOfBooks)
        {
            listOfBooking.Add(new BookingTableViewModel()
            {
                LabNo=Book.LabId,
                StartTime=Book.StartDateTime.ToString(),
                EndTime=Book.EndDateTime.ToString(),
                Description=Book.Description,
                BookId=Book.BookingId
               //match the data to the variable of BookingTableViewModel object
                
            });
            Console.WriteLine(Book.BookingId);
        }
        
        return listOfBooking;
    }

    // public async Task<ViewDeviceViewModel> viewDevice()
    // {
    //     //retrieve data from db
    //     List<Core.Entities.Device> deviceList = await _deviceRepository.GetAllAsync();
    //             
    //     //map entity model to view model
    //     List<DeviceViewModel> devices = _mapper.Map<List<Core.Entities.Device>, List<DeviceViewModel>> (deviceList);
    //         
    //     //add list of device view model to the view device view model
    //     ViewDeviceViewModel viewDevices = new ViewDeviceViewModel();
    //     viewDevices.DeviceList = devices;
    //     return viewDevices;
    // }


    public async Task<List<BookingDashboardViewModel>> RetrieveList()
    {
        var listOfLabs = await _labProfileDomainService.ViewLabs();
        //Store the lab data list in the variable listofbook .
        List<BookingDashboardViewModel> listOfLab = new List<BookingDashboardViewModel>();
         //Create list of BookingDashboardViewModel object to store the data
        foreach (Lab lab in listOfLabs)
        {
            listOfLab.Add(new BookingDashboardViewModel()
            {
                LabNo = lab.LabId,
                LabTotalUser = lab.Capacity,
                LabState = lab.LabStatus,
                LabOccupancy = lab.Occupied,
                LabLocation = lab.LabLocation
                //match the data to the variable of BookingDashboardViewModel object
            });
        }
        return listOfLab;
    }

       public async Task<Booking?> CreateBook(BookFormModel Book, string userid)
    {
      var bookWrapper = new Booking
        {  
            StartDateTime = Book.StartTime,
            EndDateTime = Book.EndTime,
            Description=Book.Description,
            LabId = Book.LabId,
            UserId = userid
         
            //create new Booking object which is same as the schema in database to store data of user input 
        };
        Console.WriteLine("Booking Services");
        return await _BookingDomainService.NewBook(bookWrapper);
        //pass the object to domain service
    }

       public async Task<Booking?> DeleteBook(int bookid)
    {
      
           
   
        return await _BookingDomainService.DeleteBook(bookid);
        //pass the variable of bookid to domain service
    }
    
}
