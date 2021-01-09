function solve() {
   
   let input = document.getElementById('num');
   let number = input.value;
   let numbers = [];

   for(let i = 1; i <= number; i++) {

      if(number % i === 0) {

         numbers.push(i);
      }
   }

   let result = document.getElementById('result');
   result.textContent = numbers.join(' ');
}