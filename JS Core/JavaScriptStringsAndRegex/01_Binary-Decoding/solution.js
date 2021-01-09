function solve() {

  let input = document.getElementsByTagName('input');
  let inputValue = input[0].value;

  let inputValueArr = inputValue.split('').map(Number);
  let elementsSum = 0;

  for(let i = 0; i < inputValueArr.length; i++) { 
      if(inputValueArr[i] === 1) {
          elementsSum += inputValueArr[i];
      }
  }

  let weight = 0;

  while(elementsSum > 9) {
      let elementsSumArr = elementsSum.toString().split('').map(Number);
      elementsSum = elementsSumArr.reduce((a, b) => a + b, 0);
  }

  weight = elementsSum;
  inputValueArr = inputValueArr.slice(weight, inputValueArr.length - weight);

  let text = '';
  let i = 0;
  let step = 8;

  while(inputValueArr.length !== 0) {
      let currentBinaryWord = inputValueArr.splice(i, step).join('');
      
      let asciiCode = parseInt(currentBinaryWord, 2);

      if((asciiCode > 96 && asciiCode < 123) || (asciiCode > 64 && asciiCode < 91) || asciiCode === 32) {
          text += String.fromCharCode(parseInt(currentBinaryWord, 2));
      }

  }

  let span = document.getElementById('result');
  span.textContent = text;
}