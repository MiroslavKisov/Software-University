(function solve() {
    Array.prototype.last = function() {
        return this[this.length - 1];
    };

    Array.prototype.skip = function(n) {
        let resultArr = [];

        resultArr = this.slice(n);

        return resultArr;
    };

    Array.prototype.take = function(n) {
        let resultArr = [];

        resultArr = this.slice(0, n);
        
        return resultArr;
    };

    Array.prototype.sum = function() {
        let sum = 0;

        for(let number of this) {
            sum += number;
        }

        return sum;
    };

    Array.prototype.average = function() {
        let sum = 0;

        for(let number of this) {
            sum += number;
        }

        return sum / this.length; 
    };

})();
