
using Microsoft.AspNetCore.Mvc;
using PrimevalAPI.Models.Repository;
using System.Collections;
using System.Threading.Tasks;
using System.Linq;
namespace PrimevalAPI.Services
{
    public class ServicesRepository {
        public readonly RepositoryContext _context;

        public ServicesRepository(RepositoryContext context) {
            _context = context;
        }


        public bool _userRegister(Repository User) {
            if (User != null) {
                if (User.Role == null) {
                    User.Role = "user";
                }
                if(User.Email == "" || User.Password == "" || User.NickName == "") {
                    return false;
                }
                _context.Add(User);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<Repository> _userLogin(Repository User) {
            foreach (Repository item in _context._repositorySet) {
                if (item.Email == User.Email && item.Password == User.Password) {
                    return item;
                }
            }
            return null;
        }
        public bool _lostpassValidate(Repository User) {
            foreach (Repository item in _context._repositorySet) {
                if (item.Email == User.Email) {
                    return true;
                }
            }
            return false;
        }

        public Repository _resetPass(Repository User) {
            var result = (from item in _context._repositorySet where item.Email.Equals(User.Email) select item).First();
            result.Password = User.Password;
            _context.SaveChanges();
            return result;
        }
    }
}
