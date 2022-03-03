using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProva.Repository.Impl;
using Xunit;
using  AppProva.Entities;

namespace AppProvaTest
{
    public class UserRepositoryServiceTest
    {


        //      GETUSER

        [Fact]
        public void GetUser_ShouldWork()
        {
            User user = new User() { Id = Guid.NewGuid() };
            List<User> users = new List<User>() {user};
            UserRepository u = new UserRepository(users);
            Assert.NotNull(u.GetUser(user.Id));

        }




        [Fact]
        public void GetUser_ShouldFail()
        {
            User user = new User() { Id = Guid.NewGuid() };
            List<User> users = new List<User>() {user};
            UserRepository u = new UserRepository(users);
            Assert.Null(u.GetUser(Guid.NewGuid()));
        }


        //       INSERT

        [Fact]
        public void InsertUser_ShouldWork()
        {
            User user = new User() { Id = Guid.NewGuid()};
            List<User> users = new List<User>(); 
            UserRepository u = new UserRepository(users);
            u.Insert(user);
            Assert.True(u._listUsers.Count == 1);
            Assert.Contains<User>(user, u._listUsers);

        }




        //        DELETE

        [Fact]
        public void DeleteUser_ShouldWork()
        {
            User user = new User() { Id = Guid.NewGuid() };
            List<User> users = new List<User>() { user };
            UserRepository u = new UserRepository(users);
            u.Delete(user.Id);
            Assert.True(u._listUsers.Count == 0);


        }



        //         UPDATE

        [Fact]
        public void Updateuser_ShouldUpdate()
        {
            User user = new User() { Id = Guid.NewGuid() };
            List<User> users = new List<User>() {user};
            UserRepository u = new UserRepository(users);
            u.Update(user.Id);
            Assert.True(user.Email == "newemail@gmail.com");


        }



        //         GETALL

        [Fact]
        public void GetAllUsers_ShouldWork()
        {
            User user = new User() { Id = Guid.NewGuid() };
            List<User> users = new List<User>() { user};
            UserRepository u = new UserRepository(users);
            Assert.Contains<User>(user, u.GetAll());
        }

    }
}



//                 // PER CREARE UN UTENTE 

// [Fact]
// public void isNull_invalidUserShouldFail()
// {
//     List<User> users = new List<User>();
//     User nullUser = new User("Mario", "Rossi", "");
//     nullUser = null;
//     UserRepository userRepositoryService = new UserRepository(users);
//     Assert.Throws<ArgumentNullException>(() => userRepositoryService.isNull(nullUser));
// }




// [Fact]
// public void addUser_ShouldAdd()
// {   
//     User newUser = new User("Mario", "Rossi", "ksgdvsd");
//     List<User> listOfUsers = new List<User>();
//     UserRepository userRepository = new UserRepository();
//     userRepository.addUserToList(listOfUsers, newUser);
//     Assert.True(listOfUsers.Count == 1);
//     Assert.Contains<User>(newUser, listOfUsers);

// }


// [Fact]
// public void createUser_ShouldCreate()
// {
//     User newUser = new User("Mario", "Rossi", "email");
//     List<User> listOfUsers = new List<User>();
//     UserRepository newUserRepository = new UserRepository(listOfUsers, newUser);  
//     newUserRepository.CreateUser(newUser);
//     Assert.True(newUserRepository._listUsers.Count == 1);
//     Assert.Contains<User>(newUser, listOfUsers);

// }

// [Fact]
// public void createUser_ShouldFail()
// {
//     User newUser = new User("Mario", "Rossi", "email");
//     //User newUser2 = new User("Mario", "Rossi", "e");
//     List<User> listOfUsers = new List<User>() { newUser};
//     UserRepository newUserRepository = new UserRepository(listOfUsers, newUser);
//     newUserRepository.CreateUser(newUser);
//     Assert.True(newUserRepository._listUsers.Count == 1);

// }


//                 // PER MODIFICARE L'UTENTE

// [Fact]
// public void isThereUser_ShouldWork()
// {
//     UserRepository service = new UserRepository();
//     List<User> users = new List<User>();
//     User user = new User("Mario", "Rossi", "mariorossi@gmail.com");
//     users.Add(user);
//     string insertedName = "Mario";
//     string insertedEmail = "mariorossi@gmail.com";
//     string newName = "Marco";
//     string newEmail = "marco@gmail.com";
//     service.isThereUser(users, user, insertedName, insertedEmail, newName, newEmail);
//     Assert.True(users[0].email== "marco@gmail.com" && users[0].Name == "Marco");

// }

// [Fact]
// public void isThereUser_ShouldFail()
// {
//     UserRepository service = new UserRepository();
//     List<User> users = new List<User>();
//     User user = new User("Mario", "Rossi", "mariorossi@gmail.com");
//     users.Add(user);
//     string insertedName = "Mario";
//     string insertedEmail = "mario@gmail.com";
//     string newName = "Marco";
//     string newEmail = "marco@gmail.com";
//     service.isThereUser(users, user, insertedName, insertedEmail, newName, newEmail);
//     Assert.True(users[0].email == "mariorossi@gmail.com" && users[0].Name == "Mario");

// }

// [Fact]
// public void UpdateUser_ShouldUpdate()
// {
//     User user = new User("Mario", "Rossi", "mariorossi@gmail.com");
//     List<User> users = new List<User>();
//     users.Add(user);
//     UserRepository services = new UserRepository(users,user);
//     services.UpdateUser(user, "Marco", "marco@gmail.com");
//     Assert.True(services._listUsers[0].email == "marco@gmail.com" && services._listUsers[0].Name == "Marco");


// }



//             //  PER ELIMINARE L'UTENTE

// [Theory]
// [InlineData("Lorenzo", "Benigni","","email")]  //email should be the wrong parameter
//public void isNullEmail_ShouldWork(string name, string surname, string email, string param)
// {
//     User user = new User(name,surname,email);
//     List<User> users = new List<User>() { user };
//     UserRepository u = new UserRepository(users,user);
//     Assert.Throws<ArgumentException>(param, () => u.isNullEmail(user));

// }

// [Theory]
// [InlineData("", "Benigni", "lorenzo@gmail", "Name")]  //Name should be the wrong parameter
// public void isNullName_ShouldWork(string name, string surname, string email, string param)
// {
//     User user = new User(name, surname, email);
//     List<User> users = new List<User>() { user };
//     UserRepository u = new UserRepository(users, user);
//     Assert.Throws<ArgumentException>(param, () => u.isNullName(user));

// }

// [Theory]
// [InlineData("Lorenzo", "", "lorenzo@gmail.com", "Surname")]
// public void isNullaSurnale_ShouldWork(string name, string surname, string email, string param)
// {
//     User user= new User(name, surname, email);
//     UserRepository u = new UserRepository();
//     List<User> users = new List<User>(){ user };
//     Assert.Throws<ArgumentException>(param, () => u.isNullSurname(user));
// }

// [Fact]
// public void FindAndRemove_ShouldWork()
// {
//     User user = new User("Mario", "Rossi", "mario@gmail.com");
//     List<User> users = new List<User>(){ user };
//     UserRepository u = new UserRepository(users, user);
//     u.FindAndRemove(users, user);
//     Assert.True(users.Count == 0);
// }

// [Fact]
// public void DeleteUser_ShouldWork()
// {
//     User user = new User("Mario", "Rossi", "mario@gmail.com");
//     List<User> users=new List<User>(){ user };
//     UserRepository u = new UserRepository(users, user);
//     u.DeleteUser(user);
//     Assert.True(u._listUsers.Count == 0);
// }

