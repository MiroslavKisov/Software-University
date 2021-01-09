const handlers = {}

$(() => {
  const app = Sammy('#root', function () {
    this.use('Handlebars', 'hbs');

    this.get('/index.html', handlers.getHome);
    this.get('/', handlers.getHome);
    this.get('#/home', handlers.getHome);
    this.get('#/register', handlers.getRegister);
    this.get('#/login', handlers.getLogin);
    this.get('#/logout', handlers.logoutUser);
    this.get('#/all-songs', handlers.getAllSongs);
    this.get('#/my-songs', handlers.getMySongs);
    this.get('#/add-song', handlers.getAddSong);
    this.get('#/like/:songId', handlers.likeSong);
    this.get('#/listen/:songId', handlers.listenSong);
    this.get('#/remove/:songId', handlers.removeSong);

    this.post('#/register', handlers.registerUser);
    this.post('#/login', handlers.loginUser);
    this.post('#/add-song', handlers.postAddSong);
  });
  app.run();
});