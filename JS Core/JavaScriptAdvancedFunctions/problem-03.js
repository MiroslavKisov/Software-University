const solve = (function() {

    let sum = 0

    function add(num) {

        sum += num;
        return add;
    }

    add.toString = function() { return sum; }

    return add;

})();


solve(5)(7)(4);