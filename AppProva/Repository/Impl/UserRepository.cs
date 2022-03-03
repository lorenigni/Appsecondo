using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Entities;
using Microsoft.Extensions.Logging;

namespace AppProva.Repository.Impl
{
    public class UserRepository : IUserRepository
    {

        public List<User> _listUsers;
        public ILogger<UserRepository> _logger;


        public UserRepository(ILogger<UserRepository> logger)
        {
            _listUsers = new List<User>();
            this._logger = logger;
        }
        public UserRepository(List<User> listUsers, ILogger<UserRepository> logger) //Overload
        : this(logger)
        {
            this._listUsers = listUsers;


        }

        public UserRepository(List<User> listUsers)
        {
            _listUsers = listUsers;
        }

        public UserRepository()
        {
        }

        public User Insert(User user)
        {

            foreach (User u in _listUsers)
            {
                if (u.Id == user.Id)
                {
                    _logger.LogWarning($"{user.Id}  user id is not available");
                    throw new InvalidIdException(user.Id);

                }
            }

            _listUsers.Add(user);
            return user;
        }



        public User GetUser(Guid id)
        {

            try
            {
                _listUsers = _listUsers.Where(User => User.Id == id).ToList();
                if (_listUsers.Count > 0) { return _listUsers.FirstOrDefault(); }
                else throw new InvalidIdException(id);

            }

            catch (InvalidIdException e)
            {
                _logger.LogWarning($"There is no user with id {id}");
                Console.WriteLine(e.Message.ToString());
            }
            return null;

        }


        public IEnumerable<User> GetAll()
        {
            List<User> allUsers = new List<User>();
            foreach (User u in _listUsers)
            {
                allUsers.Add(u);
            }
            return allUsers;
        }



        public void Delete(Guid id)
        {
            if (_listUsers.Count > 0)
            {
                _listUsers = _listUsers.Where(User => User.Id != id).ToList();

            }
        }


        public User Update(Guid id)
        {
            if (_listUsers.Count != 0)
            {
                foreach (User u in _listUsers)
                {
                    try
                    {
                        if (u.Id == id)
                        {
                            string newEmail = "newemail@gmail.com";
                            u.Email = newEmail;
                            return u;

                        }
                    }
                    catch (InvalidIdException ex)

                    {
                        _logger.LogWarning($"There is no user with id {id}");
                        Console.WriteLine(ex.Message);
                    }

                }

            }
            return null;

        }
    }
}







