namespace IRunes.App.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using Constants;
    using Models;
    using SIS.HTTP.Common;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;

    public class AlbumController : BaseController
    {
        public IHttpResponse AlbumsView(IHttpRequest httpRequest)
        {
            if (this.Db.Albums.Any())
            {
                var albumListView = CreateAlbumList();
                File.WriteAllText(AppConstants.AlbumListFragmentsPath, albumListView);
                return this.View(AppConstants.AlbumListFragmentsPath, AppConstants.LoginTemplatePath);
            }

            return this.View(AppConstants.AlbumsPath, AppConstants.LoginTemplatePath);
        }

        public IHttpResponse CreateAlbumsView(IHttpRequest httpRequest)
        {
            return this.View(AppConstants.CreateAlbumPath, AppConstants.LoginTemplatePath);
        }

        public IHttpResponse CreateAlbum(IHttpRequest httpRequest)
        {
            var albumName = httpRequest.FormData[AppConstants.AlbumName].ToString();
            var cover = httpRequest.FormData[AppConstants.Cover].ToString();

            if (string.IsNullOrEmpty(albumName) || string.IsNullOrEmpty(cover))
            {
                return new RedirectResult(AppConstants.CreateAlbumsRoute);
            }

            var album = new Album
            {
                Name = albumName,
                Cover = cover,
            };

            this.Db.Albums.Add(album);

            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception)
            {
                return this.ServerError(Messages.InternalServerErrorMessage);
            }

            var response = (HtmlResult)this.View(AppConstants.AlbumSuccessPath, AppConstants.LoginTemplatePath);
            //response.AddCookie(new HttpCookie(AppConstants.AlbumCookieKey, album.Id));
            //response.Cookies.Add(new HttpCookie(AppConstants.AlbumCookieKey, album.Id));
            return response;
        }

        public IHttpResponse AlbumDetailsView(IHttpRequest httpRequest)
        {
            var albumId = httpRequest.QueryData[AppConstants.QueryId].ToString();
            var album = this.Db.Albums.FirstOrDefault(e => e.Id == albumId);

            if (album == null)
            {
                this.ServerError(Messages.InternalServerErrorMessage);
            }

            var albumDetailsViewFragment = CreateAlbumDetails(album);
            File.WriteAllText(AppConstants.AlbumDetailsFragmentsPath, albumDetailsViewFragment);
            return this.View(AppConstants.AlbumDetailsFragmentsPath, AppConstants.LoginTemplatePath);
        }

        private string CreateAlbumList()
        {
            var sb = new StringBuilder();
            var albumsHtml = File.ReadAllText(AppConstants.AlbumListPath);
            var albumListFragment = File.ReadAllText(AppConstants.AlbumsPath);
            albumListFragment = albumListFragment.Replace(AppConstants.NoCurrentAlbums, "");
            sb.Append(albumListFragment);
            var albums = this.Db.Albums.ToList();

            foreach (var album in albums)
            {
                var albumListItem = albumsHtml.Replace(AppConstants.AlbumNamePlaceholder, album.Name);
                albumListItem = albumListItem.Replace(AppConstants.QueryIdPlaceholder, album.Id);
                sb.Append(albumListItem);
            }

            return sb.ToString();
        }

        private string CreateAlbumDetails(Album album)
        {
            var sb = new StringBuilder();

            var albumDetailsHtml = File.ReadAllText(AppConstants.AlbumDetailsPath);
            albumDetailsHtml = albumDetailsHtml.Replace(AppConstants.ImagePlaceholder, WebUtility.UrlDecode(album.Cover));
            albumDetailsHtml = albumDetailsHtml.Replace(AppConstants.AlbumNamePlaceholder, album.Name);
            albumDetailsHtml = albumDetailsHtml.Replace(AppConstants.AlbumPricePlaceholder, album.Price.ToString("F2"));
            albumDetailsHtml = albumDetailsHtml.Replace(AppConstants.QueryIdPlaceholder, album.Id);

            if (album.Tracks.Any())
            {
                foreach (var track in album.Tracks)
                {
                    var trackItem = AppConstants.TrackItemPlaceholder.Replace(AppConstants.QueryIdPlaceholder, track.Name);
                    trackItem = trackItem.Replace(AppConstants.AlbumIdPlaceholder, album.Id);
                    trackItem = trackItem.Replace(AppConstants.TrackIdPlaceholder, track.Id);
                    sb.AppendLine(trackItem);
                }
            }

            if (sb.Length != 0)
            {
                albumDetailsHtml = albumDetailsHtml.Replace(AppConstants.NoCurrentTracks, sb.ToString().TrimEnd());
            }

            return albumDetailsHtml;
        }
    }
}
