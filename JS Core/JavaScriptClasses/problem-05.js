let result = (function solve() {
    class myObj {
        constructor() {
            this.id = myObj.incrementId();
        }

        static incrementId() {
            if (!this.latestId) {

                this.latestId = 1;

            } else { 

                this.latestId++;
            }

            return this.latestId;
        }

        extend(template) {
            const entries = Object.entries(template);

            for(let [key, value] of entries) {
                if(typeof value === 'function') {

                    Object.getPrototypeOf(this)[key] = value;

                } else {

                    this[key] = value;
                }
            }
        }
    }

    return myObj;

})();

let obj1 = new result();
console.log(obj1.id);
let obj2 = new result();
console.log(obj2.id);
obj1.extend({
    extensionMethod: function () { console.log('Hi'); },
    extensionProperty: 'someString'
});
obj1.extensionMethod();
console.log(obj1);