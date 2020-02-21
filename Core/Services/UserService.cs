using Api.Core.Model.Data;
using Api.Core.Model.DTOs;
using Api.Core.Model.Entities;
using Api.Core.Model.Services;
using System;

namespace Api.Core.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public long AddUser(UserDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var userEntity = MapDtoToEntity(user);

            return Convert.ToInt64(UnitOfWork.User.Add(userEntity));
        }

        public UserDto GetUserInformationByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException();
            }

            var result = UnitOfWork.User.GetUserInformationByEmail(email);

            if (result == null)
            {
                throw new ArgumentException();
            }

            return new UserDto(result);
        }

        public void RemoveUser(long userId)
        {
            if (userId == 0)
            {
                throw new ArgumentNullException();
            }

            UnitOfWork.User.Remove(userId);
        }

        public void UpdateUser(UserDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var userEntity = MapDtoToEntity(user);

            UnitOfWork.User.Update(userEntity);
        }

        private User MapDtoToEntity(UserDto dto)
        {
            return new User()
            {
                UserId = dto.UserId,
                Email = dto.Email,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
            };
        }
    }
}
