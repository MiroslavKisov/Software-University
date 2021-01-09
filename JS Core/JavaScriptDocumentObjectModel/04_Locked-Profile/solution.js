function solve() {
   
   let buttons = Array.from(document.getElementsByTagName('button'));

   for(let i = 0; i < buttons.length; i++) {
      buttons[i].id = i + 1;
      buttons[i].addEventListener('click', showContent);
   }

   function showContent(event) {
      
      let button = event.target;

      if(button.id === '1') {
         
         let radioButtons = document.getElementsByName('user1Locked');
         let lockButton = radioButtons[0];
         let unlockButton = radioButtons[1];
         let hiddenDiv = document.getElementById('user1HiddenFields');

         moveDiv(unlockButton, hiddenDiv);

      } else if(button.id === '2') {

         let radioButtons = document.getElementsByName('user2Locked');
         let lockButton = radioButtons[0];
         let unlockButton = radioButtons[1];
         let hiddenDiv = document.getElementById('user2HiddenFields');

         moveDiv(unlockButton, hiddenDiv);

      } else if(button.id === '3') {

         let radioButtons = document.getElementsByName('user3Locked');
         let lockButton = radioButtons[0];
         let unlockButton = radioButtons[1];
         let hiddenDiv = document.getElementById('user3HiddenFields');

         moveDiv(unlockButton, hiddenDiv);
      }

      function moveDiv(unlockButton, hiddenDiv) {

         if (unlockButton.checked) {
            if (hiddenDiv.style.display === '') {
               hiddenDiv.style.display = 'block';
               button.removeEventListener('click', showContent);
               button.textContent = 'Hide it';
               button.addEventListener('click', function () { hideContent(unlockButton, hiddenDiv, button); });
            }
         }
      }
   }

   function hideContent(unlockButton, hiddenDiv, button) {

      if(unlockButton.checked) {
         hiddenDiv.style.display = '';
         button.removeEventListener('click', function() { hideContent(unlockButton, hiddenDiv, button) });
         button.textContent = 'Show more';
         button.addEventListener('click', showContent);
      }
   }
} 