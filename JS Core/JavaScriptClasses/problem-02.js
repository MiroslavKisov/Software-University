function solve(inputArgs, sortingCriteria) {
    let tickets = [];

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    for(let argument of inputArgs) {
        let ticketInfo = argument.split('|');

        let destination = ticketInfo[0];
        let price = Number(ticketInfo[1]);
        let status = ticketInfo[2];

        let currentTicket = new Ticket(destination, price, status);

        tickets.push(currentTicket);
    }

    if(sortingCriteria === 'destination') {
        tickets.sort((a, b) => { 
            if(a.destination > b.destination) {
                return 1;
            }

            if(a.destination < b.destination) {
                return -1;
            }

            return 0;
        });

    } else if(sortingCriteria === 'status') {
        tickets.sort((a, b) => { 
            if(a.status > b.status) {
                return 1;
            }

            if(a.status < b.status) {
                return -1;
            }

            return 0;
        });

    } else if(sortingCriteria === 'price') {
        tickets.sort((a, b) => { 
            if(a.price > b.price) {
                return 1;
            }

            if(a.price < b.price) {
                return -1;
            }

            return 0;
        });
    }

    return tickets;
}

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'price'
);