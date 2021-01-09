function solve(input) {
    
    input.sort(sortByTwoCriteria);
    
    input.forEach(x => console.log(x));

    function sortByTwoCriteria(elementOne, elementTwo) {

        let elementOneLength = elementOne.length;
        let elementTwoLength = elementTwo.length;

        if(elementOneLength > elementTwoLength) {

            return 1;

        } else if(elementOneLength < elementTwoLength) {

            return -1;

        } else if(elementOneLength === elementTwoLength) {

            if(elementOne > elementTwo) {

                return 1;

            } else if(elementOne < elementTwo) {

                return -1;

            } else if (elementOne === elementTwo) {

                return 0;
            }
        }
    }
}

solve(['beta', 'alpha', 'gamma']);