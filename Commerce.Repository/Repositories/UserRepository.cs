using AutoMapper;
using Commerce.Repository.Data;
using Commerce.Repository.Entities;
using Commerce.Repository.Models;
using System.Linq;

namespace Commerce.Repository.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        UserModel GetExistedUser(AuthenticateModel model);
    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IMapper _mapper;
        public UserRepository(CommerceContext dbcontext, IMapper mapper) : base(dbcontext, mapper)
        {
            _mapper = mapper;
        }

        public UserModel GetExistedUser(AuthenticateModel model)
        {
            return _mapper.Map<User, UserModel>(DbContext.Users.FirstOrDefault(x =>
                                x.UserName == model.UserName &&
                                x.Password == model.Password &&
                                x.IsDeleted == false));
        }
    }
}
