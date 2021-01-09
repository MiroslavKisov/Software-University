function solve(day, service, hour) {

    let price;

    if(service === 'Fitness')
    {
        if(hour >= 8.00 && hour <= 15.00)
        {
            if(day === 'Saturday' || day === 'Sunday')
            {
                price = 8.00;
            }
            else
            {
                price = 5.00;
            }
        }
        else if(hour > 15.00 && hour <= 22.00)
        {
            if(day === 'Saturday' || day === 'Sunday')
            {
                price = 8.00;
            }
            else
            {
                price = 7.50;
            }
        }

        console.log(price);
    }
    else if(service === 'Sauna')
    {
        if(hour >= 8.00 && hour <= 15.00)
        {
            if(day === 'Saturday' || day === 'Sunday')
            {
                price = 7.00
            }
            else
            {
                price = 4.00;
            }
        }
        else if(hour > 15.00 && hour <= 22.00)
        {
            if(day === 'Saturday' || day === 'Sunday')
            {
                price = 7.00;
            }
            else
            {
                price = 6.50;
            }
        }

        console.log(price);
    }
    else if(service === 'Instructor')
    {
        if(hour >= 8.00 && hour <= 15.00)
        {
            if(day === 'Saturday' || day === 'Sunday')
            {
                price = 15.00;
            }
            else
            {
                price = 10.00;
            }
        }
        else if(hour > 15.00 && hour <= 22.00)
        {
            if(day === 'Saturday' || day === 'Sunday')
            {
                price = 15.00;
            }
            else
            {
                price = 12.50;
            }
        }

        console.log(price);
    }
}

solve('Monday', 'Sauna', 15.30);