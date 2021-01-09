function solution(command) {

    let post = this;

    let obfuscatedDownVotes = post.downvotes;
    let obfuscatedUpvotes = post.upvotes;
    let totalVotes = post.upvotes + post.downvotes;
    let biggestRating = post.downvotes >= post.upvotes ? post.downvotes : post.upvotes;
    let rating = '';

    if(command === 'upvote') {

        post.upvotes += 1;

    } else if(command === 'downvote') {

        post.downvotes += 1;

    } else if(command === 'score') {

        if(totalVotes > 50) {
            
            obfuscatedDownVotes = post.downvotes + Math.ceil(biggestRating * 0.25);
            obfuscatedUpvotes = post.upvotes + Math.ceil(biggestRating * 0.25);

        } 
        
        let isHot = post.upvotes > totalVotes * 0.66;
        let isControversial = (post.upvotes - post.downvotes >= 0) && (post.upvotes > 100 || post.downvotes > 100);
        let isUnpopular = post.upvotes - post.downvotes < 0;
        let isNew = totalVotes < 10;

        if(isNew || !isHot && !isControversial && !isUnpopular) {

            rating = 'new';

        } else if(isHot) {

            rating = 'hot';

        } else if(isControversial) {

            rating = 'controversial';

        } else if(isUnpopular) {

            rating = 'unpopular';
        }
    }

    return [obfuscatedUpvotes, obfuscatedDownVotes, obfuscatedUpvotes - obfuscatedDownVotes, rating];
}
