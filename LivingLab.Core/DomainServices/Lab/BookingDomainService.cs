using LivingLab.Core.Entities;
using LivingLab.Core.Repositories.Lab;

using Microsoft.Extensions.Logging;

namespace LivingLab.Core.DomainServices.Lab;
/// <summary>
/// Domain service implementations belongs here.
/// Domain service are classes that are responsible for business logic.
/// </summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class BookingDomainService: IBookingDomainService
{
     private readonly IBookingRepository _BookingRepository;
    private readonly ILogger _logger;
    
    //initialise repository 
      public BookingDomainService(IBookingRepository BookingRepository, ILogger<IBookingRepository> logger)
    {
        _BookingRepository = BookingRepository;
        _logger = logger;
        //initalise Bookingrepository
    }
     //Function to Insert new booking data 
    public async Task<Booking> NewBook(Booking book)
    {
        Console.WriteLine("Booking Domain Services");
          return await _BookingRepository.AddAsync(book);
          //Using function of Repository class to add Book
    }

    //function to get current booking data 
    public Task<List<Booking>> ViewBooks()
    {
        return _BookingRepository.GetAllBooking();
        //Retrevie all the database of booking in book table
    } 

    //function to delete booking by their bookid
      public async Task<Booking> DeleteBook(int bookid)
    {
        return await _BookingRepository.DeleteAsync(bookid);
       //delete book with the input bookid
    }

   
}
