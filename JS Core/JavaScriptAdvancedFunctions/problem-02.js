function solve() {
    
    let numberOfOccurrences = [];
    let sortedValues = [];

    for(let i = 0; i < arguments.length; i++) {

        console.log(typeof(arguments[i]) + ': ' + arguments[i]);

        if(!numberOfOccurrences[typeof(arguments[i])]) {

            numberOfOccurrences[typeof(arguments[i])] = 1;

        } else {

            numberOfOccurrences[typeof(arguments[i])]++;
        }
    }

    for(let element in numberOfOccurrences) {

        sortedValues.push({type: element, number: numberOfOccurrences[element]});
    }

    sortedValues.sort(sortArr);
    
    for(let element in sortedValues) {

        console.log(`${sortedValues[element].type} = ${sortedValues[element].number}`);
    }
    
    function sortArr(a, b) {

        if(a.number > b.number) {

            return -1;

        } else if(a.number < b.number) {

            return 1;

        } else {

            return 0;
        }
    }
}

solve('cat', 42, 52, 'asd', 11, function () { console.log('Hello world!'); });