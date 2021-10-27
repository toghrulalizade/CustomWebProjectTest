using Core.Entities;
using Core.Entities.Dto;
using Core.Entities.Dto.Base;
using System;

namespace Core.Utilities.Helper
{
    public static class CustomMapper
    {
        public static GetUserDto MapToGetUserDtoFromModel(this User user)
        {
            GetUserDto result = new GetUserDto()
            {
                Id = user.Id,
                AuthenticationToken = user.AuthenticationToken,
                Email = user.Email,
                IsActive = user.IsActive,
                IsConfirmed = user.IsConfirmed,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username
            };

            return result;
        }

        public static User MapToUserFromGetDto(this GetUserDto user)
        {
            User result = new User()
            {
                Id = user.Id,
                AuthenticationToken = user.AuthenticationToken,
                Email = user.Email,
                IsActive = user.IsActive,
                IsConfirmed = user.IsConfirmed,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username
            };

            return result;
        }

        public static UpdateUserDto MapToUpdateUserDtoFromModel(this User user)
        {
            UpdateUserDto result = new UpdateUserDto()
            {
                Id = user.Id,
                AuthenticationToken = user.AuthenticationToken,
                Email = user.Email,
                IsActive = user.IsActive,
                IsConfirmed = user.IsConfirmed,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username
            };

            return result;
        }

        public static User MapUserFromUpdateDto(this UpdateUserDto user)
        {
            User result = new User()
            {
                Id = user.Id,
                AuthenticationToken = user.AuthenticationToken,
                Email = user.Email,
                IsActive = user.IsActive,
                IsConfirmed = user.IsConfirmed,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username
            };

            return result;
        }

        public static User MapUserFromInsertDto(this InsertUserDto user)
        {
            var passwordGeneratedResult = RegisterHelper.GenerateSaltedHash(user.Password);

            User result = new User()
            {
                AuthenticationToken = Guid.NewGuid().ToString().Trim().Replace("-", string.Empty),
                Email = user.Email,
                IsActive = user.IsActive,
                IsConfirmed = user.IsConfirmed,
                Name = user.Name,
                Surname = user.Surname,
                Username = user.Username,
                PasswordHash = passwordGeneratedResult.Hash,
                PasswordSalt = passwordGeneratedResult.Salt
            };

            return result;
        }
    }
}
