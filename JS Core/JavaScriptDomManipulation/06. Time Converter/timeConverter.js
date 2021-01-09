function attachEventsListeners() {
    const hoursCoefficient = 24;
    const minutesSecondsCoefficient = 60;

    let daysBtn = $('#daysBtn').on('click', convertFromDays);
    let hoursBtn = $('#hoursBtn').on('click', convertFromHours);
    let minutesBtn = $('#minutesBtn').on('click', convertFromMinutes);
    let secondsBtn = $('#secondsBtn').on('click', convertFromSeconds);

    let days = $('#days');
    let hours = $('#hours');
    let minutes = $('#minutes');
    let seconds = $('#seconds');

    function convertFromDays() {
        hours.val(days.val() * hoursCoefficient);
        minutes.val(days.val() * hoursCoefficient * minutesSecondsCoefficient);
        seconds.val(days.val() * hoursCoefficient * minutesSecondsCoefficient * minutesSecondsCoefficient);
    }

    function convertFromHours() {
        days.val(hours.val() / hoursCoefficient);
        minutes.val(hours.val() * minutesSecondsCoefficient);
        seconds.val(hours.val() * minutesSecondsCoefficient * minutesSecondsCoefficient);
    }

    function convertFromMinutes() {
        days.val(minutes.val() / (hoursCoefficient * minutesSecondsCoefficient));
        hours.val(minutes.val() / minutesSecondsCoefficient);
        seconds.val(minutes.val() * minutesSecondsCoefficient);
    }

    function convertFromSeconds() {
        days.val(seconds.val() / (hoursCoefficient * minutesSecondsCoefficient * minutesSecondsCoefficient));
        hours.val(seconds.val() / (minutesSecondsCoefficient * minutesSecondsCoefficient));
        minutes.val(seconds.val() / minutesSecondsCoefficient);
    }
}