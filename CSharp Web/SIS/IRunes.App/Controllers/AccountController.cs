namespace IRunes.App.Controllers
{
    using System;
    using Services.Contracts;
    using Services;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.HTTP.Common;
    using System.Linq;
    using Models;
    using SIS.WebServer.Results;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Cookies;
    using Constants;

    public class AccountController : BaseController
    {
        private IHashService hashService;

        public AccountController()
        {
            this.hashService = new HashService();
        }

        public IHttpResponse Register(IHttpRequest httpRequest)
        {
            return this.View(AppConstants.RegisterPath, AppConstants.ViewTemplatePath);
        }

        public IHttpResponse Login(IHttpRequest httpRequest)
        {
            return this.View(AppConstants.LoginPath, AppConstants.ViewTemplatePath);
        }

        public IHttpResponse RegisterUser(IHttpRequest httpRequest)
        {
            var userName = httpRequest.FormData[AppConstants.Username].ToString().Trim();
            var password = httpRequest.FormData[AppConstants.Password].ToString();
            var email = httpRequest.FormData[AppConstants.Email].ToString();
            var hashPassword = hashService.Hash(password);

            if (string.IsNullOrWhiteSpace(userName) || userName.Length < 4)
            {
                return new RedirectResult(AppConstants.UsersRegisterRoute);
            }

            if (this.Db.Users.Any(e => e.Username == userName))
            {
                return new RedirectResult(AppConstants.UsersRegisterRoute);
            }

            if (this.Db.Users.Any(e => e.Email == email))
            {
                return new RedirectResult(AppConstants.UsersRegisterRoute);
            }

            if (!email.Contains(AppConstants.At))
            {
                return new RedirectResult(AppConstants.UsersRegisterRoute);
            }

            var user = new User
            {
                Username = userName,
                Password = hashPassword,
                Email = email,
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


            return this.View(AppConstants.RegisteredPath, AppConstants.ViewTemplatePath, user.Username);
        }

        public IHttpResponse LoginUser(IHttpRequest httpRequest)
        {
            if (httpRequest.FormData.Count == 0)
            {
                return new RedirectResult(AppConstants.UsersLoginRoute);
            }

            var userName = httpRequest.FormData[AppConstants.Username].ToString().Trim();
            var password = httpRequest.FormData[AppConstants.Password].ToString();
            var hashPassword = hashService.Hash(password);

            var user = this.Db.Users.FirstOrDefault(e => (e.Email == userName || e.Username == userName) && e.Password == hashPassword);

            if (user == null)
            {
                return BadRequestError(Messages.InvalidUsernameOrPassword);
            }

            var cookieContent = UserCookieService.GetUserCookie(user.Username);
            var response = (HtmlResult)this.View(AppConstants.LoggedInPath, AppConstants.LoginTemplatePath, user.Username);
            response.Cookies.Add(new HttpCookie(AppConstants.AuthIRunes, cookieContent, 7));
            return response;
        }
    }
}
