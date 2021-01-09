class Rat {
    constructor(name) {
        this.name = name;
        this.rats = [];
    }

    unite(rat) {
        if(rat instanceof Rat) {
            this.rats.push(rat);
        }
    }

    getRats() {
        return this.rats;
    }

    toString() {
        let result = this.name + '\n';

        for(let rat of this.rats) {
            result += '##' + rat.name + '\n';
        }
        
        return result;
    }
}

