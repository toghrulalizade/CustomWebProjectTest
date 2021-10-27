using Business.ExternalServices.Mail;
using Business.Services;
using Core.Entities.Dto;
using Core.Utilities.Resource.Enum;
using Core.Utilities.Resource.UsableModels.Constants;
using Core.Utilities.Resource.UsableModels.MailTemplate;
using Core.Utilities.Resource.UsableModels.MailTemplate.Sendgrid;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MvcWEB.Models;
using System;

namespace MvcWEB.Controllers
{
    public class RegisterController : Controller
    {
        private readonly SendgridService _mailService;
        private readonly UserManager _userManager;

        public RegisterController()
        {
            _mailService = new SendgridService();
            _userManager = new UserManager();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var model = new LoginUserDto();
            return View(model);
        }


        public IActionResult LogOut()
        {
            HttpContext.Response.Cookies.Delete("SignedUser");
            return new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Register", action = "SignIn" }));
        }

        [HttpPost("/Register/SignIn")]
        public IActionResult SignIn(LoginUserDto loginUser)
        {
            if (ModelState.IsValid)
            {
                var result = _userManager.AuthenticateUser(loginUser);
                if (!result.IsSuccess)
                {
                    return View("_ErrorView",
                        new ResultMessage
                        {
                            AlertStatus = AlertStatus.danger.ToString(),
                            Message = result.ResultMessage
                        });
                }

                int rememberMinute = 15;
                if (loginUser.RememberMe)
                {
                    rememberMinute = 10000;
                }
                var user = _userManager.Get(x => x.Username == loginUser.Username);
                HttpContext.Response.Cookies.Append("SignedUser", user.AuthenticationToken, new CookieOptions { Expires = DateTime.Now.AddMinutes(rememberMinute) });

                return RedirectToAction("Index", "Home", new ResultMessage
                {
                    AlertStatus = AlertStatus.success.ToString(),
                    Message = result.ResultMessage
                });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult CreateAccount()
        {
            var model = new InsertUserDto();
            return View(model);
        }

        [HttpPost("/Register/CreateAccount")]
        public IActionResult CreateAccount(InsertUserDto user)
        {
            if (ModelState.IsValid)
            {
                var result = _userManager.RegisterUser(user);

                if (result != null)
                {
                    return View("_SuccessView",
                        new ResultMessage
                        {
                            AlertStatus = AlertStatus.success.ToString(),
                            Message = string.Format(MessageContainer.SuccessMessage.RegistrationCompletedSuccesfully, result.Name, result.Surname, result.Email)
                        });
                }

                return View("_ErrorView",
                    new ResultMessage
                    {
                        AlertStatus = AlertStatus.danger.ToString(),
                        Message = MessageContainer.ErrorMessage.RegistrationFailed
                    });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult ConfirmAccount(int id)
        {
            var result = _userManager.ConfirmUser(x => x.Id == id);
            if (result != null)
            {
                return View("_SuccessView",
                    new ResultMessage
                    {
                        AlertStatus = AlertStatus.success.ToString(),
                        Message = string.Format(MessageContainer.SuccessMessage.ConfirmationSucceed, result.Name, result.Surname)
                    });
            }
            return View("_ErrorView",
                new ResultMessage
                {
                    AlertStatus = AlertStatus.danger.ToString(),
                    Message = MessageContainer.ErrorMessage.ConfirmationFailed
                });
        }

        [HttpGet("/Register/PrepareRecovery")]
        public IActionResult PrepareRecovery()
        {
            var model = new RecoveryMailDto();
            return View(model);
        }

        [HttpPost("/Register/PrepareRecovery")]
        public IActionResult PrepareRecovery(RecoveryMailDto model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = _userManager.Get(x => x.Email == model.UserEmail);

                if (currentUser == null)
                {
                    return View("_ErrorView",
                        new ResultMessage
                        {
                            AlertStatus = AlertStatus.danger.ToString(),
                            Message = MessageContainer.ErrorMessage.UserIsNotFound
                        });
                }
                MailRequest mailRequest = new MailRequest
                {
                    IsHtmlContent = false,
                    Subject = "Şifrə Yeniləmə Poçtu",
                    FromEmail = "togrul.alizade.325@gmail.com",
                    ToEmail = currentUser.Email,
                    ContentText = string.Empty
                };

                RecoverOrConfirmationTemplate template = new RecoverOrConfirmationTemplate()
                {
                    MailSubject = mailRequest.Subject,
                    RedirectLink = "https://localhost:44310/Register/RecoverPassword/" + currentUser.Id,
                    UserFirstName = currentUser.Name
                };

                var mailIsSent = _mailService.SendRecoveryMail(mailRequest, template);

                if (!mailIsSent)
                    return View("_ErrorView",
                        new ResultMessage
                        {
                            AlertStatus = AlertStatus.danger.ToString(),
                            Message = MessageContainer.ErrorMessage.EmailIsNotSent
                        });

                return View("_SuccessView",
                new ResultMessage
                {
                    AlertStatus = AlertStatus.success.ToString(),
                    Message = MessageContainer.SuccessMessage.RegisterRecoveryPrepareSucceed
                });
            }
            else
            {
                return View(model);
            }
        }



        [HttpGet("/Register/RecoverPassword")]
        public IActionResult RecoverPassword(int id)
        {
            PasswordChangeDto user = new PasswordChangeDto
            {
                Id = id
            };

            return View(user);
        }

        [HttpPost("/Register/RecoverPassword")]
        public IActionResult RecoverPassword(PasswordChangeDto model)
        {
            if (ModelState.IsValid)
            {
                var result = _userManager.RecoverUserPassword(model);

                if (!result)
                {
                    return View("_ErrorView",
                        new ResultMessage
                        {
                            AlertStatus = AlertStatus.danger.ToString(),
                            Message = MessageContainer.ErrorMessage.UserRecoveryProcessFailed
                        });
                }
                return View("_SuccessView",
                    new ResultMessage
                    {
                        AlertStatus = AlertStatus.success.ToString(),
                        Message = MessageContainer.SuccessMessage.UserRecoveryProcessSucceed
                    });
            }
            else
            {
                return View(model);
            }
        }
    }
}
