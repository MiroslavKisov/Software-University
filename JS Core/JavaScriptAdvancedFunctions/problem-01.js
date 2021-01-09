function solve(arr, sortType) {

    function sortAscending(a, b) {

        if(a > b) {

            return 1;

        } else if(a < b) {

            return -1;

        } else {

            return 0;
        }
    }

    function sortDescending(a, b) {

        if(a > b) {

            return -1;

        } else if(a < b) {

            return 1;

        } else {

            return 0;
        }
    }

    let sortMethods = {
        'asc' : sortAscending,
        'desc' : sortDescending,
    }

    return arr.sort(sortMethods[sortType]);
}
//USE
solve([14, 7, 17, 6, 8], 'asc');