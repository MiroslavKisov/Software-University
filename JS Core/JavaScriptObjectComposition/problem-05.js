(function solve() {
    String.prototype.ensureStart = function(str) {
        let result = this.toString();

        if(!this.startsWith(str)) {
            return str + result;
        }

        return result;
    }

    String.prototype.ensureEnd = function(str) {
        let result = this.toString();

        if(!this.endsWith(str)) {
            return result + str;
        }

        return result
    }

    String.prototype.isEmpty = function() {
        if(this.toString() === '') {
            return true;
        }

        return false;
    }

    String.prototype.truncate = function(n) {
        let result = this.toString();

        if(n >= this.length) {
            return result.toString();
        }

        if(n < this.length) {
            let thisSplit = this.split(' ');

            if(thisSplit.length > 1) {

                while((thisSplit.join(' ') + '...').length > n) {
                    thisSplit.pop();
                }

                result = thisSplit.join(' ') + '...';
                return result.toString();
            }

            if(n >= 4) {
                result = this.substring(0, n - 3);
                result += '...';
                return result;
            }

            return '.'.repeat(n);
        }
    }

    String.format = function(str, ...params) {
        let result = '';
        let pattern = /{([0-9]+)}/gm;
        let matches = str.match(pattern);

        for(let match of matches) {
            if(params[Number(match[1])]) {
                str = str.replace(match, params[Number(match[1])]);
            }
        }

        result = str;

        return result;
    }
})();

let s = '';
let is = ''.isEmpty();
console.log(is);

