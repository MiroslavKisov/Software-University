namespace Cake.App.Controllers
{
    using System;
    using Models;
    using Services;
    using Services.Contracts;
    using SIS.HTTP.Common;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;
    using System.Linq;
    using SIS.HTTP.Cookies;

    public class AccountController : BaseController
    {
        private IHashService hashService;

        public AccountController()
        {
            this.hashService = new HashService();
        }

        public IHttpResponse Register(IHttpRequest httpRequest)
        {
            return this.View("register");
        }

        public IHttpResponse Login(IHttpRequest httpRequest)
        {
            return this.View("login");
        }

        public IHttpResponse DoRegister(IHttpRequest httpRequest)
        {
            var username = httpRequest.FormData["username"].ToString().Trim();
            var password = httpRequest.FormData["password"].ToString();
            var confirmPassword = httpRequest.FormData["confirmPassword"].ToString();

            if (string.IsNullOrWhiteSpace(username) || username.Length < 4)
            {
                return this.BadRequestError(Messages.InvalidUsername);
            }

            if (this.Db.Users.Any(e => e.Username == username))
            {
                return this.BadRequestError(Messages.SameUsername);
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                return this.BadRequestError(Messages.InvalidPassword);
            }

            if (password != confirmPassword)
            {
                return this.BadRequestError(Messages.DifferentPasswords);
            }

            var hashPasword = this.hashService.Hash(password);

            var user = new User
            {
                Name = username,
                Username = username,
                Password = hashPasword,

            };

            this.Db.Users.Add(user);
            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception)
            {
                return this.ServerError(Messages.InternalServerErrorMessage);
            }

            return new RedirectResult("/");
        }

        public IHttpResponse DoLogin(IHttpRequest request)
        {
            var username = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var hashPassword = this.hashService.Hash(password);

            var user = this.Db.Users.FirstOrDefault(e => e.Username == username && e.Password == hashPassword);

            if (user == null)
            {
                this.BadRequestError(Messages.InvalidUsernameOrPassword);
            }

            var cookieContent = UserCookieService.GetUserCookie(user.Username);
            var response = new RedirectResult("/");
            response.Cookies.Add(new HttpCookie(".auth-cakes", cookieContent, 7));
            return response;
        }
    }
}
