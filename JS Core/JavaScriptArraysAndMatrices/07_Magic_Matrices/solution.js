function solve(matrix) {

    let sum = matrix[0].reduce((a, b) => a + b, 0);
    let isMagic = true;

    let sumRows = getSumRows(matrix);

    for (let element of sumRows) {

        if(element !== sum) {

            isMagic = false;
            break;
        }
    }

    let sumCols = matrix.reduce(function (r, a) {
        a.forEach(function (b, i) {
            r[i] = (r[i] || 0) + b;
        });
        return r;
    }, []);

    for (let element of sumCols) {

        if(element !== sum) {

            isMagic = false;
            break;
        }
    }

    console.log(isMagic);

    function getSumRows(matrix) {

        let rowsSum = [];

        for(let row of matrix) {

            let sum = row.reduce((a, b) => a + b, 0);
            rowsSum.push(sum);
        }

        return rowsSum;
    }
}

solve([[1, 2, 3], [1, 2, 3], [1, 2, 3]]);