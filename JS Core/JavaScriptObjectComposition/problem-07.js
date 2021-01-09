function solve(selector) {
    let fatherNode = document.querySelector(selector);
    
    let deepestNode = traverse(fatherNode);

    for(let node of deepestNode.tags) {
        node.classList.add('highlight');
    }

    function traverse(htmlNode) {
        let currentNodeChildren = htmlNode.children;

        let node = {
            tags : [],
            depth : 0
        };

        for(let i = 0; i < currentNodeChildren.length; i++) {
            let currentNode = traverse(currentNodeChildren[i]);
            if(currentNode.depth > node.depth) {
                node = currentNode;
            }
        }

        node.tags.push(htmlNode);
        node.depth++;
        return node;
    }
}