let solution = (function() {

    const add = function([xa, xb], [ya, yb]) {

        return [xa + ya, xb + yb];
    }

    const multiply = function([xa, xb], scalar) {

        return [xa * scalar, xb * scalar];
    }

    const length = function([xa, xb]) {

        return Math.sqrt((xa * xa) + (xb * xb));
    }

    const dot = function([xa, xb], [ya, yb]) {

        return (xa * ya) + (xb * yb);
    }

    const cross = function([xa, xb], [ya, yb]) {

        return (xa * yb) - (ya * xb);
    }

    return {
        add,
        multiply,
        length,
        dot,
        cross
    }
})();

console.log(solution.add([1, 1], [1, 0]));
console.log(solution.multiply([3.5, -2], 2));
console.log(solution.length([3, -4]));
console.log(solution.dot([1, 0], [0, -1]));
console.log(solution.cross([3, 7], [1, 0]));
