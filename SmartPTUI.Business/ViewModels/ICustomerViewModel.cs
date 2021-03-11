using SmartPTUI.Data.Enums;
using System;

namespace SmartPTUI.Business.ViewModels
{
    public interface ICustomerViewModel
    {
        CurrentHealthRating CurrentHealth { get; set; }
        DateTime DOB { get; set; }
        string FirstName { get; set; }
        Gender Gender { get; set; }
        int Height { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
    }
}