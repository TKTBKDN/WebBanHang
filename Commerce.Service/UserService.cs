using AutoMapper;
using Commerce.Repository.Entities;
using Commerce.Repository.Enums;
using Commerce.Repository.Helper;
using Commerce.Repository.Models;
using Commerce.Repository.Repositories;
using Commerce.Repository.UnitOfWorks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Service
{
    public interface IUserService
    {
        Task<int> AddUser(UserModel model);
        string Authenticate(AuthenticateModel authenticateModel);
    }
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private IConfiguration _config;
        private readonly IUserRepository _userRepository;
        public UserService(IOptions<AppSettings> appSettings, IMapper mapper, 
            IUnitOfWork unitOfWork, IConfiguration config, IUserRepository userRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
            _userRepository = userRepository;
        }

        public async Task<int> AddUser(UserModel model)
        {
            try
            {
                var entity = _mapper.Map<User>(model);

                _unitOfWork.UserRepository.Add(entity);

                _unitOfWork.Commit();

                return entity.Id;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw;
            }
        }

        public string Authenticate(AuthenticateModel user)
        {
            var currentUser = _userRepository.GetExistedUser(user);
            if(currentUser != null)
            {
                return GenerateToken(currentUser);
            }
            return null;
        }

        private string GenerateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role,  Enum.GetName(typeof(Role), user.Role))
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddHours(1),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
