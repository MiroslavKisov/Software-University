function solve(args) {

    let obj = {};

    for(let i = 0; i < args.length; i+=2)
    {
        let food = args[i];
        let calories = Number(args[i + 1]);

        obj[food] = calories;
    }

    console.log(obj);
}

solve(['Yogurt',48, 'Rise', 138, 'Apple', 52]);