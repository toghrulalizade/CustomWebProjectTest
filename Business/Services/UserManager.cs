using AutoMapper;
using Business.ExternalServices.Mail;
using Core.Entities;
using Core.Entities.Dto;
using Core.Utilities.Helper;
using Core.Utilities.Resource;
using Core.Utilities.Resource.UsableModels.Constants;
using Core.Utilities.Resource.UsableModels.MailTemplate;
using Core.Utilities.Resource.UsableModels.MailTemplate.Sendgrid;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Services
{
    public class UserManager
    {
        private UserDal _userDal;
        private SendgridService _mailService;

        public UserManager()
        {
            _userDal = new UserDal();
            _mailService = new SendgridService();
        }

        public List<GetUserDto> GetList(Expression<Func<User, bool>> filter = null)
        {
            List<GetUserDto> result = new List<GetUserDto>();

            _userDal.GetList(filter).ForEach(x =>
            {
                result.Add(x.MapToGetUserDtoFromModel());
            });

            return result;
        }

        public GetUserDto Get(Expression<Func<User, bool>> filter)
        {
            return _userDal.Get(filter).MapToGetUserDtoFromModel();
        }

        public GetUserDto ConfirmUser(Expression<Func<User, bool>> filter)
        {
            var currentUser = _userDal.GetWithoutCondition(filter);

            if (currentUser == null)
                return null;

            currentUser.IsActive = true;
            currentUser.IsConfirmed = true;

            var resultUpdate = _userDal.Update(currentUser);

            if (resultUpdate <= 0)
                return null;

            return _userDal.Get(filter).MapToGetUserDtoFromModel();
        }

        public GetUserDto RegisterUser(InsertUserDto user)
        {
            var insertableUser = user.MapUserFromInsertDto();
            var result = insertableUser.MapToGetUserDtoFromModel();
            if (_userDal.Add(insertableUser) <= 0)
            {
                return null;
            }
            result.Id = _userDal.GetWithoutCondition(x => x.Email == user.Email).Id;
            var mailRequest = new MailRequest
            {
                IsHtmlContent = false,
                ContentText = string.Empty,
                FromEmail = "togrul.alizade.325@gmail.com",
                ToEmail = user.Email,
                Subject = "Hesab Tesdiqleme Poctu"
            };
            var mailTemplate = new RecoverOrConfirmationTemplate
            {
                MailSubject = mailRequest.Subject,
                RedirectLink = "https://localhost:44310/Register/ConfirmAccount/" + result.Id,
                UserFirstName = result.Name
            };

            var resultMail = _mailService.SendConfirmationMail(mailRequest, mailTemplate);
            if (resultMail)
                return result;

            return null;
        }

        public bool RecoverUserPassword(PasswordChangeDto model)
        {
            bool result = false;
            var recoverableUser = _userDal.Get(x=>x.Id == model.Id);
            if (recoverableUser != null)
            {
                var passwordCryptoContainer = RegisterHelper.GenerateSaltedHash(model.Password);
                recoverableUser.PasswordHash = passwordCryptoContainer.Hash;
                recoverableUser.PasswordSalt = passwordCryptoContainer.Salt;
                if (_userDal.Update(recoverableUser) > 0)
                {
                    result = true;
                }
            }
            
            return result;
        }

        public ProcessResult AuthenticateUser(LoginUserDto credential)
        {
            var result = new ProcessResult();
            var user = _userDal.Get(x => x.Username == credential.Username);
            if (user == null)
            {
                result.IsSuccess = false;
                result.ResultMessage = MessageContainer.ErrorMessage.UserIsNotFound;
            }
            if (user != null && !user.IsConfirmed)
            {
                result.IsSuccess = false;
                result.ResultMessage = MessageContainer.ErrorMessage.UserMustBeConfirmedByEmail;
            }
            result.IsSuccess = RegisterHelper.VerifyPassword(credential.Password, user.PasswordHash, user.PasswordSalt);
            result.ResultMessage = MessageContainer.SuccessMessage.LoginSucceed;

            return result;
        }


    }
}
