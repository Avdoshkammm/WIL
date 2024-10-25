using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIL.Application.DTO;
using WIL.Application.Interfaces;
using WIL.Domain.Entities;
using WIL.Domain.Interfaces;

namespace WIL.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepository _userRepository, IMapper _mapper)
        {
            userRepository = _userRepository;
            mapper = _mapper;
        }
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            IEnumerable<User> users = await userRepository.GetUsers();
            return mapper.Map<IEnumerable<UserDTO>>(users);
        }
        public async Task<UserDTO> GetUser(int id)
        {
            User user = await userRepository.GetUserByID(id);
            return mapper.Map<UserDTO>(user);
        }
        public Task CreateUser(UserDTO userDTO)
        {
            User user = mapper.Map<User>(userDTO);
            return userRepository.CreateUser(user);
        }
        public Task UpdateUser(UserDTO userDTO)
        {
            User user = mapper.Map<User>(userDTO);
            return userRepository.UpdateUser(user);
        }
        public Task DeleteUser(int id)
        {
            return userRepository.DeleteUser(id);
        }
    }
}
