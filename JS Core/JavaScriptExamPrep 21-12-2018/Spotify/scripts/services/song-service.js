const songService = (() => {

    function getAllSongs() {
        return kinvey.get('appdata', 'songs', 'kinvey');
    }

    function addSong(data) {
        return kinvey.post('appdata', 'songs', 'kinvey', data);
    }

    function getSongById(songId) {
        return kinvey.get('appdata', `songs/${songId}`, 'kinvey');
    }

    function likeSong(song) {
        let likes = Number(song.likes) + 1;

        let data = {
            title : song.title,
            artist : song.artist,
            imageURL : song.imageURL,
            likes : likes,
            listened : song.listened,
        };

        return kinvey.update('appdata', `songs/${song._id}`, 'kinvey', data);
    }

    function listenSong(song) {
        let listened = Number(song.listened) + 1;

        let data = {
            title : song.title,
            artist : song.artist,
            imageURL : song.imageURL,
            likes : song.likes,
            listened : listened,
        };

        return kinvey.update('appdata', `songs/${song._id}`, 'kinvey', data);
    }

    function removeSong(songId) {
        return kinvey.remove('appdata', `songs/${songId}`, 'kinvey');
    }

    function filterOtherSongs(songs, userId) {
        songs = songs.filter(s => s._acl.creator !== userId);
        songs.sort(sortOtherSongs);
        return songs;
    }

    function filterMySongs(songs, userId) {
        songs = songs.filter(s => s._acl.creator === userId);
        songs.sort(sortMySongs);
        return songs;
    }

    function sortOtherSongs(a, b) {
        if(Number(a.likes) > Number(b.likes)) {
            return -1;
        }

        if(Number(a.likes) < Number(b.likes)) {
            return 1;
        }

        return 0;
    }

    function sortMySongs(a, b) {
        if(Number(a.likes) > Number(b.likes)) {
            return -1;
        }

        if(Number(a.likes) < Number(b.likes)) {
            return 1;
        }

        if(Number(a.likes) === Number(b.likes)) {

            if(Number(a.listened) > Number(b.listened)) {
                return -1;
            }

            if(Number(a.listened) < Number(b.listened)) {
                return 1;
            }

            return 0;
        }
    }

    return {
        removeSong,
        listenSong,
        likeSong,
        getSongById,
        filterOtherSongs,
        filterMySongs,
        getAllSongs,
        addSong,
    }

})();