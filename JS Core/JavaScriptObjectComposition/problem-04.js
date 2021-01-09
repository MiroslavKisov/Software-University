function solve() {
    let myObj = {
        __proto__: {},
        extend: function (extensionObj) {
            for(const [key, value] of Object.entries(extensionObj)) {
                if(typeof value === 'function') {
                    Object.getPrototypeOf(this)[key] = value;
                } else {
                    this[key] = value;
                }
            }
        }
    };

    return myObj;
}