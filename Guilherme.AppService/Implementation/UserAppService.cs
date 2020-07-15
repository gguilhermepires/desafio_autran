using Guilherme.AppService.Interfaces;
using Guilherme.Service.Contracts.RequestResponse.Base;
using Guilherme.Service.Contracts.RequestResponse.User;
using Guilherme.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Guilherme.AppService.Implementation
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _service;

        public UserAppService(IUserService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<ResponseMessage<UserResponse>> LoginUserAsync(UserRequest request)
        {
            var response = new ResponseMessage<UserResponse>();
            try
            {
                response.Data = await _service.LoginUserAsync(request);
                response.StatusCode = (int)HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Error = new Error(e.Message, e.StackTrace);
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return response;
        }

        public async Task<ResponseMessage<UserResponse>> AddUserAsync(UserRequest request)
        {
            var response = new ResponseMessage<UserResponse>();

            try
            {
                response.Data = await _service.AddUserAsync(request);
                response.StatusCode = (int)HttpStatusCode.Created;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Error = new Error(e.Message, e.StackTrace);
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return response;
        }

        public async Task<ResponseMessage<UserResponse>> GetByUserIdAsync(Guid id)
        {
            var response = new ResponseMessage<UserResponse>();

            try
            {
                response.Data = await _service.GetByUserIdAsync(id);
                response.StatusCode = (int)HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Error = new Error(e.Message, e.StackTrace);
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return response;
        }

        public async Task<ResponseMessage<IEnumerable<UserResponse>>> GetAllUsersAsync()
        {
            var response = new ResponseMessage<IEnumerable<UserResponse>>();

            try
            {
                response.Data = await _service.GetAllAsync();
                response.StatusCode = (int)HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Error = new Error(e.Message, e.StackTrace);
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return response;
        }

        public async Task<ResponseMessage<UserResponse>> UpdateUserAsync(Guid id, UserRequest request)
        {
            var response = new ResponseMessage<UserResponse>();

            try
            {
                response.Data = await _service.UpdateUserAsync(id, request);
                response.StatusCode = (int)HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Error = new Error(e.Message, e.StackTrace);
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return response;
        }

        public async Task<ResponseMessage<string>> DeleteUserAsync(Guid id)
        {
            var response = new ResponseMessage<string>();

            try
            {
                await _service.DeleteUserAsync(id);

                response.Data = $"Usuário com ID {id} foi removido com sucesso!";
                response.StatusCode = (int)HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Error = new Error(e.Message, e.StackTrace);
                response.StatusCode = (int)HttpStatusCode.NotFound;
            }

            return response;
        }
    }
}