using System.ComponentModel.DataAnnotations;

using LivingLab.Core.Enums;

using Microsoft.AspNetCore.Identity;

namespace LivingLab.Core.Entities.Identity;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
///<summary>
/// The Application user created by EF core, below are attributes added to the template IdentityUser
/// </summary>
public class ApplicationUser : IdentityUser
{
    // Add additional profile data for application users by adding properties to this class
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public NotificationType PreferredNotification { get; set; }
    public string? AuthenticationType { get; set; }
    public int? OTP { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime SMSExpiry { get; set; }
    public string? UserFaculty { get; set; }
    public List<Booking> Bookings { get; set; }
    public List<Lab> Labs { get; set; }
}
