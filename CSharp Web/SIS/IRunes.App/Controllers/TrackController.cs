namespace IRunes.App.Controllers
{
    using Constants;
    using Models;
    using SIS.HTTP.Common;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;

    public class TrackController : BaseController
    {
        private string albumQueryId;

        public IHttpResponse CreateTrackView(IHttpRequest httpRequest)
        {
            albumQueryId = httpRequest.QueryData[AppConstants.QueryAlbumId].ToString();
            var trackView = ParseTrackView();
            File.WriteAllText(AppConstants.AlbumTracksPath, trackView);
            return this.View(AppConstants.AlbumTracksPath, AppConstants.LoginTemplatePath);
        }

        public IHttpResponse CreateTrack(IHttpRequest httpRequest)
        {
            var trackName = httpRequest.FormData[AppConstants.TrackName].ToString();
            var trackLink = httpRequest.FormData[AppConstants.TrackLink].ToString();
            var price = httpRequest.FormData[AppConstants.TrackPrice].ToString();
            albumQueryId = httpRequest.QueryData[AppConstants.QueryAlbumId].ToString();

            if (string.IsNullOrEmpty(trackName))
            {
                return this.View(AppConstants.AlbumDetailsFragmentsPath, AppConstants.LoginTemplatePath);
            }

            if (string.IsNullOrEmpty(trackLink))
            {
                return this.View(AppConstants.AlbumDetailsFragmentsPath, AppConstants.LoginTemplatePath);
            }

            if (string.IsNullOrEmpty(price))
            {
                return this.View(AppConstants.AlbumDetailsFragmentsPath, AppConstants.LoginTemplatePath);
            }

            var trackPrice = decimal.Parse(price);

            var track = new Track
            {
                Name = trackName,
                Link = trackLink,
                Price = trackPrice,
                AlbumId = this.albumQueryId,
            };

            this.Db.Tracks.Add(track);

            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception)
            {
                return this.ServerError(Messages.InternalServerErrorMessage);
            }

            var currentAlbum = this.Db.Albums.Find(this.albumQueryId);

            if (!currentAlbum.Tracks.Any())
            {
                return this.View(AppConstants.AlbumDetailsFragmentsPath, AppConstants.LoginTemplatePath);
            }

            var albumViewWithTracks = ParseAlbumTracksList(currentAlbum);
            File.WriteAllText(AppConstants.AlbumDetailsFragmentsPath, albumViewWithTracks);
            return this.View(AppConstants.AlbumDetailsFragmentsPath, AppConstants.LoginTemplatePath);
        }

        public IHttpResponse TrackDetailsView(IHttpRequest httpRequest)
        {
            var trackDetailsView = ParseTrackDetails(httpRequest);
            File.WriteAllText(AppConstants.TrackDetailsFragmentPath, trackDetailsView);
            return this.View(AppConstants.TrackDetailsFragmentPath, AppConstants.LoginTemplatePath);
        }

        private string ParseTrackDetails(IHttpRequest httpRequest)
        {
            var albumId = httpRequest.QueryData[AppConstants.QueryAlbumId].ToString();
            var trackId = httpRequest.QueryData[AppConstants.QueryTrackId].ToString();
            var currentTrack = this.Db.Tracks.Find(trackId);
            var trackView = File.ReadAllText(AppConstants.TrackDetailsPath);
            trackView = trackView.Replace(AppConstants.AlbumLinkPlaceholder, WebUtility.UrlDecode(currentTrack.Link));
            trackView = trackView.Replace(AppConstants.TrackNamePlaceholder, currentTrack.Name);
            trackView = trackView.Replace(AppConstants.TrackPricePlaceholder, currentTrack.Price.ToString());
            trackView = trackView.Replace(AppConstants.QueryIdPlaceholder, albumId);

            return trackView;
        }

        private string ParseTrackView()
        {
            var trackView = File.ReadAllText(AppConstants.CreateTrackFragmentPath);
            trackView = trackView.Replace(AppConstants.QueryIdPlaceholder, this.albumQueryId);
            return trackView;
        }

        private string ParseAlbumTracksList(Album album)
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

            albumDetailsHtml = albumDetailsHtml.Replace(AppConstants.NoCurrentTracks, sb.ToString().TrimEnd());

            return albumDetailsHtml;
        }
    }
}
