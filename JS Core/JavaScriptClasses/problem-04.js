class Stringer {
    constructor(str, len) {
        this.innerLength = len;
        this.innerString = str;
        this.resultString = '';
    }

    increase(len) {
        this.innerLength += len;
    }

    decrease(len) {
        this.innerLength -= len;

        if(this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString() {
        this.resultString = this.innerString.substring(0, this.innerLength);

        if(this.resultString.length < this.innerString.length) {
            this.resultString += '...';
        }

        return this.resultString;
    }
}