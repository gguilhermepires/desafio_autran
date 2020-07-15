using System;
using System.Net.Http;
using Guilherme.Domain.Entities;
using Guilherme.Service.Contracts.RequestResponse.User;

namespace Guilherme.Services.Implementation.Map
{
    public static class UserMap
    {
        public static User ToUpdateUser(this UserRequest request, User model)
        {
            if (model == null)
                throw new HttpRequestException("O contrato enviado não pode ser processado devido a um erro!");

            if (!string.IsNullOrEmpty(request.Password))
            {
                model.AddBCryptPassword(request.Password);
                request.Password = model.Password;
            }

            return new User
            (
                model.Id,
                request.Name ?? model.Name,
                request.Email ?? model.Email,
                request.Password ?? model.Password,
                request.Claim ?? model.Claim
            );
        }

        public static User ToUser(this UserRequest request)
        {
            var user = new User(Guid.NewGuid(), request.Name, request.Email, request.Password, request.Claim);
            user.AddBCryptPassword(request.Password);
            return user;
        }

        public static UserResponse ToResponse(this User model, string token = null)
        {
            return new UserResponse
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                Claim = model.Claim,
                Token = token
            };
        }
    }
}