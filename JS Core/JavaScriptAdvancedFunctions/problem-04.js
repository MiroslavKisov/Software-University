function solve(name, age, weight, height) {

    let BMI = weight / Math.pow(height / 100, 2);
    let status = '';

    switch(true){
        
        case (BMI < 18.5):
        status = 'underweight';
        break;

        case (BMI >= 18.5 && BMI < 25):
        status = 'normal';
        break;

        case (BMI >= 25 && BMI < 30):
        status = 'overweight';
        break;

        case (BMI >= 30):
        status = 'obese';
        break;
    }

    let person = {

        name : name,

        personalInfo : {

            age : Math.round(age),
            weight : Math.round(weight),
            height : Math.round(height),
        },

        BMI : Math.round(BMI),
        status : status, 
    };

    if(status === 'obese') {

        person.recommendation = 'admission required'; 
    }

    return person;
}

solve('Peter', 29, 175, 182);