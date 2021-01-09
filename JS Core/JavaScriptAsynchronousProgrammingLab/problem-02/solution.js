function attachEvents() {
    $('#btnLoadPosts').on('click', loadPosts);
    $('#btnViewPost').on('click', viewPost);
    let $postTitle = $('#post-title');
    let $postsBody =  $('#post-body');
    let $postComments = $('#post-comments');
    let $selectPost = $('#posts');
    const baseUrl = ``;
    const username = 'guest';
    const password = 'guest';
    const base64auth = btoa(username + ":" + password);
    const authHeaders = {"Authorization": "Basic " + base64auth};

    function loadPosts() {

        $.get({
            url : baseUrl + `/posts`,
            headers : authHeaders,
        })
            .then(populateSelectList)
            .catch(displayError);

        function populateSelectList(data) {
            let posts = data;

            for(const post of posts) {
                
                $selectPost.append($('<option>').val(post._id).text(post.title));
            }
        }
    }

    function displayError(err) {
        let errorDiv = $("<div>").text("Error: " +
          err.status + ' (' + err.statusText + ')');
        $(document.body).prepend(errorDiv);
        setTimeout(function() {
          $(errorDiv).fadeOut(function() {
            $(errorDiv).remove();
          });
        }, 3000);
      }

    function viewPost() {

        let postId = $('#posts option:selected').val();
        let postUrl = baseUrl + `/posts` + `/` + postId;
        let commentsUrl = baseUrl + `/comments/?query={"post_id":"${postId}"}`

        let getPost = $.ajax({
            url: postUrl,
            headers : authHeaders,
        });
        
        let getComments = $.ajax({
            url: commentsUrl,
            headers : authHeaders,
        });

        Promise.all([getPost, getComments])
        .then(displayContent)
        .catch(displayError);

        function displayContent([post, comments]) {
            $postTitle.empty();
            $postsBody.empty();
            $postComments.empty();

            $postTitle.text(post.title);
            $postsBody.text(post.body);

            for(const comment of comments) {

                $postComments.append($('<li>').text(comment.text));
            }
        }
    }
}
