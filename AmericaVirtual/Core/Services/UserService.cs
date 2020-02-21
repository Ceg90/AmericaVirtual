using AmericaVirtual.Data;
using AmericaVirtual.Model.DTOs;
using AmericaVirtual.Model.Entities;
using AmericaVirtual.Model.Services;
using System;

namespace AmericaVirtual.Core.Services
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
                throw new ArgumentNullException("Los datos del usuario son incorrectos.");
            }

            var userEntity = MapDtoToEntity(user);

            return Convert.ToInt64(UnitOfWork.User.Add(userEntity));
        }

        public UserDto GetUserInformationByEmail(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("El correo electrónico es inválido.");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("La contraseña es inválida.");
            }

            var result = UnitOfWork.User.GetUserInformationByEmail(email, password);

            if (result == null)
            {
                throw new ArgumentException("El usuario no está registrado.");
            }

            InsertUserAction(result.UserId, "LogIn");

            return new UserDto(result);
        }

        public void LogOut(int userId)
        {
            if(UnitOfWork.User.GetById(userId) == null)
            {
                throw new ArgumentNullException("El usuario es inválido.");
            }
            
            InsertUserAction(userId, "LogOut");
        }

        public void RemoveUser(int userId)
        {
            if (userId == 0)
            {
                throw new ArgumentNullException("El usuario es inválido.");
            }

            UnitOfWork.User.Remove(userId);
        }

        public int UserPurchase(int userId, int productId)
        {
            if (UnitOfWork.User.GetById(userId) == null)
            {
                throw new ArgumentNullException("El usuario es inválido.");
            }

            if (UnitOfWork.Product.GetById(productId) == null)
            {
                throw new ArgumentNullException("El usuario es inválido.");
            }

            InsertUserAction(userId, "Compra");

            return Convert.ToInt32(UnitOfWork.UserPurchases.Add(new UserPurchases()
            {
                UserId = userId,
                ProductId = productId
            }));
        }

        public void UpdateUser(UserDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Los datos del usuario son incorrectos.");
            }

            var userEntity = MapDtoToEntity(user);

            UnitOfWork.User.Update(userEntity);
        }

        private void InsertUserAction(int userId, string action)
        {
            UnitOfWork.UserActions.Add(new UserActions()
            {
                UserId = userId,
                Action = action,
                Date = DateTime.Now
            });
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
