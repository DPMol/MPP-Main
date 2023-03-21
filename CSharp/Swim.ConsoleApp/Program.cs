// See https://aka.ms/new-console-template for more information

using Swim.Data.Repositories.UserRepositories;
using Swim.Domain.Models.UserModels;

var repo = new UserRepository();

repo.Save(new User()
{
    Username = "bob",
    Password = "radu"
});
var users = repo.FindAll();
System.Diagnostics.Debug.WriteLine("CIAO");
