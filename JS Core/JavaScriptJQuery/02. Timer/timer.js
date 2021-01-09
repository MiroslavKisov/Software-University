function timer() {
   const stepMiliseconds = 1000;
   const maxBorderValue = 60;
   const minBorderValue = 0;

   let secondsSpan = $('#seconds');
   let minutesSpan = $('#minutes');
   let hoursSpan = $('#hours');
   
   let time = {
      seconds : 0,
      minutes : 0,
      hours : 0,
      t : {},

      startTimer : function() {
         startButton.off('click', time.startTimer);
         time.t = setInterval(time.runTime, stepMiliseconds);
      },

      stopTimer : function() {
         startButton.click(time.startTimer);
         clearInterval(time.t);
      },

      runTime : function() {
         time.seconds++;
         
         if(time.seconds === maxBorderValue) {
            time.seconds = minBorderValue;
            time.minutes++;
         }
         
         if(time.minutes === maxBorderValue) {
            time.minutes = minBorderValue;
            time.hours++;
         }

         secondsSpan.text(('0' + time.seconds).slice(-2));
         minutesSpan.text(('0' + time.minutes).slice(-2));
         hoursSpan.text(('0' + time.hours).slice(-2));
      }
   }

   let startButton = $('#start-timer').click(time.startTimer);
   let stopButton = $('#stop-timer').click(time.stopTimer);
}