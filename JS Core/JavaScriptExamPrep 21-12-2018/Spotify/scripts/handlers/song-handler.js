handlers.getAllSongs = function(ctx) {
    songService.getAllSongs()
        .then(function(songs) {

        let userId = sessionStorage.getItem('userId');
        let otherSongs = songService.filterOtherSongs(songs, userId);
        let mySongs = songService.filterMySongs(songs, userId);

        ctx.isAuth = userService.isAuth;
        ctx.username = sessionStorage.getItem('username');
        ctx.otherSongs = otherSongs;
        ctx.mySongs = mySongs;

        ctx.loadPartials({
            header : './templates/common/header.hbs',
            footer : './templates/common/footer.hbs',
            otherSong : './templates/otherSong.hbs',
            mySong : './templates/mySong.hbs',
        })
            .then(function() {
                this.partial('./templates/allSongs.hbs');
            });
        })
        .catch(function (err) {
            notifications.showError(err.responseJSON.description);
        });
}

handlers.getMySongs = function(ctx) {

    songService.getAllSongs()
        .then(function(songs) {

            let userId = sessionStorage.getItem('userId');
            let mySongs = songService.filterMySongs(songs, userId);
            ctx.isAuth = userService.isAuth;
            ctx.username = sessionStorage.getItem('username');
            ctx.mySongs = mySongs;

            ctx.loadPartials({
                header : './templates/common/header.hbs',
                footer : './templates/common/footer.hbs',
                mySong : './templates/mySong.hbs',
            }).then(function() {
                this.partial('./templates/mySongs.hbs');
            })
            .catch(function (err) {
                notifications.showError(err.responseJSON.description);
            });
        });
}

handlers.getAddSong = function(ctx) {

    ctx.isAuth = userService.isAuth;
    ctx.username = sessionStorage.getItem('username');

    ctx.loadPartials({
        header : './templates/common/header.hbs',
        footer : './templates/common/footer.hbs',
    })
    .then(function() {
        this.partial('./templates/addSong.hbs');
    });
}

handlers.postAddSong = function(ctx) {

    let _this = this;
    let title = ctx.params.title;
    let artist = ctx.params.artist;
    let imageURL = ctx.params.imageURL;
    let urlPattern = /^http(s)?:\/\//g;

    if(title.length < 6) {
        notifications.showError('Title must be at least 6 characters long!');
        return;
    }

    if(artist.length < 3) {
        notifications.showError('Artist must be at least 3 characters long!');
        return;
    }

    if(!urlPattern.test(imageURL)) {
        notifications.showError('Invalid URL try http:// or https://');
        return;
    }

    let song = {
        title : title,
        artist : artist,
        imageURL : imageURL,
        likes : 0,
        listened : 0,
    }

    songService.addSong(song)
        .then(function(song) {
            _this.redirect('#/all-songs');
            notifications.showSuccess(`You have added a song ${song.title}`);
        })
        .catch(function (err) {
            notifications.showError(err.responseJSON.description);
        });
}

handlers.likeSong = function(ctx) {
    let songId = ctx.params.songId.split(':')[1];
    let _this = this;

    songService.getSongById(songId)
        .then(function(song) {

            songService.likeSong(song)
            .then(function() {
                notifications.showSuccess('Liked!');
                _this.redirect('#/all-songs');
            })
        }).catch(function (err) {
            notifications.showError(err.responseJSON.description);
        });
}

handlers.listenSong = function(ctx) {
    let songId = ctx.params.songId.split(':')[1];
    let _this = this;

    songService.getSongById(songId)
        .then(function(song) {

            songService.listenSong(song)
            .then(function() {
                notifications.showSuccess(`You just listened ${song.title}`);
                _this.redirect('#/my-songs');
            })
        }).catch(function (err) {
            notifications.showError(err.responseJSON.description);
        });
}

handlers.removeSong = function(ctx) {
    let songId = ctx.params.songId.split(':')[1];
    let _this = this;

    songService.removeSong(songId)
        .then(function() {
            notifications.showSuccess('Song removed successfully!');
            _this.redirect('#/my-songs');
        }).catch(function (err) {
            notifications.showError(err.responseJSON.description);
        });
}