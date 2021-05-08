using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using SmartPTUI.Areas.Identity.Data;
using SmartPTUI.Business.Transactions;
using SmartPTUI.Data;
using SmartPTUI.Data.Enums;

namespace SmartPTUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class PtRegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ICustomerTransactions _customerTransaction;

        public PtRegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            ICustomerTransactions customerTransaction)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _customerTransaction = customerTransaction;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Name must only contain letters")]
            [StringLength(30, MinimumLength = 2, ErrorMessage = "Part numbers must be between 2 and 30 character in length.")]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Name must only contain letters")]
            [StringLength(30, MinimumLength = 2, ErrorMessage = "Part numbers must be between 2 and 30 character in length.")]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Gender")]
            public Gender Gender { get; set; }

            [Required]
            [Display(Name = "Birth Date")]
            [DataType(DataType.Date)]
            public DateTime DOB { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Customer Email")]
            public string CustomerEmail { get; set; }

            [Required]
            [Display(Name = "Custom Title Colour")]
            [RegularExpression(@"^#[a-fA-F0-9]{6}$", ErrorMessage = "Must be a valid colour hex code")]
            [StringLength(7, MinimumLength = 7, ErrorMessage = "Must be a valid hex colour code")]
            public string TitleColour { get; set; }

            [Required]
            [RegularExpression(@"^#[a-fA-F0-9]{6}$", ErrorMessage = "Must be a valid colour hex code")]
            [StringLength(7, MinimumLength = 7, ErrorMessage = "Must be a valid hex colour code")]
            [Display(Name = "Custom Text Colour")]
            public string TextColour { get; set; }

            [Required]
            [RegularExpression(@"^#[a-fA-F0-9]{6}$", ErrorMessage = "Must be a valid colour hex code")]
            [StringLength(7, MinimumLength = 7, ErrorMessage = "Must be a valid hex colour code")]
            [Display(Name = "Custom Background Colour")]
            public string BackgroundColour { get; set; }

            [Required]
            [RegularExpression(@"^#[a-fA-F0-9]{6}$", ErrorMessage = "Must be a valid colour hex code")]
            [StringLength(7, MinimumLength = 7, ErrorMessage = "Must be a valid hex colour code")]
            [Display(Name = "Custom Title Bar Colour")]
            public string TopBarColour { get; set; }

            [Required]
            [Display(Name = "Custom Site Name")]
            public string SiteName { get; set; }

            [Required]
            [Display(Name = "Custom Welcome Message")]
            public string WelcomeMessage { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = Input.Email,
                    Email = Input.Email
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, "SMARTPTUIPTROLE");
                    _logger.LogInformation("User created a new account with password.");

                    //Search customer email address + add boolean if not found to invalidate

                    try
                    {
                        
                        var customerList = new List<Customer>();
                        customerList.Add(await _customerTransaction.GetCustomerViaEmail(Input.CustomerEmail));

                        var pt = new PersonalTrainer()
                        {
                            FirstName = Input.FirstName,
                            LastName = Input.LastName,
                            Gender = Input.Gender,
                            DOB = Input.DOB,
                            UserId = user.Id,
                            Customers = customerList,
                            TitleColour = Input.TitleColour,
                            TextColour = Input.TextColour,
                            BackgorundColour = Input.BackgroundColour,
                            TopBarColour = Input.TopBarColour,
                            SiteName = Input.SiteName,
                            WelcomeMessage = Input.WelcomeMessage

                        };

                        await _customerTransaction.SavePT(pt);

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                            protocol: Request.Scheme);


                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                        }
                        else
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                    }
                    catch (Exception e) {

                        ModelState.AddModelError("CustomerNotFoundError", "Could Not find the customer you entered");
                    }

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
