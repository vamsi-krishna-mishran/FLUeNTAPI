using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WEBAPIFLUENT.Context;
using WEBAPIFLUENT.DTOs;
using WEBAPIFLUENT.Models;

namespace WEBAPIFLUENT.Repository
{
    
    public interface IUserRepository
    {
        public Task<bool?> CheckUser(UserDTO userDTO);
        public Task<int?> AddUser(UserDTO userdto);
        public Task<string?> ResetPassword(string Email,string host);
        public Task<int> ForgotPassword(string token, UserDTO user);
    }
    public class UserRepository:IUserRepository
    {
        private readonly PDFContext _context;
        public UserRepository(PDFContext context)
        {
            _context = context;
        }
        private  string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Convert the password string to a byte array
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Compute the hash value of the password bytes
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convert the hash bytes to a string representation
                string hashedPassword = Convert.ToBase64String(hashBytes);

                return hashedPassword;
            }
        }
        public async Task<bool?> CheckUser(UserDTO userDTO)
        {
            var mapper = MapperConfig.InitializeAutomapper();
            var user=mapper.Map<User>(userDTO);
            string hash = HashPassword(user.Password);
            var res = await _context.users.Where(u=> u.Email == userDTO.Email &&hash==u.Password).FirstOrDefaultAsync();
            if(res == null) { return null; }
            return true;
        }
        public async Task<int?> AddUser(UserDTO userdto)
        {
            var mapper= MapperConfig.InitializeAutomapper();
            var user = mapper.Map<User>(userdto);
            string hash = HashPassword(user.Password);
            user.Password = hash;
            var res = await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return res.Entity.Id;
        }

        public async Task<string?> ResetPassword(string Email, string host)
        {
            var res =await  _context.users.Where(u => u.Email == Email).FirstOrDefaultAsync();
            if (res == null) { return null; };
            string enc = AesEncryption.Encrypt(res.Email + "$" + DateTime.Now.ToString(), "ThisIsASecretKey123",256);
            string uet= HttpUtility.UrlEncode(Email + "$" + DateTime.Now.ToString());
            EmailRepository.sendMail($"<a href={host}/api/User/forgotpassword?token={uet}>click to reset</a>");
            return uet;
        }
        public async Task<int> ForgotPassword(string token, UserDTO user)
        {
            string time;
            try
            {
                string url = HttpUtility.UrlDecode(token);
                //string t = AesEncryption.Decrypt(url, "ThisIsASecretKey123",256);
                time = url.Split('$')[1];
            }
            catch (Exception) { return 0; }//invalid token
            DateTime dt = DateTime.Parse(time);
            if (DateTime.Now - dt > TimeSpan.FromMinutes(10) ){
                return 1;//timeout error
            }
            var check = await _context.users.Where(u=>u.Email== user.Email).FirstOrDefaultAsync();
            if (check == null) { 
                return 2;//user id not present;
            }
           // check.Name = user.Name;
           // check.Email = user.Email;
            check.Password = HashPassword(user.Password);
            await _context.SaveChangesAsync();
            return 3;// user password updated successfully.
        }
       
    }
}
