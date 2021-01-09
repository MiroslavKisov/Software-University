function notify(message) {
    let notificationDiv = $('#notification').text(message).css('display', 'block');
    notificationDiv.delay(2000).fadeOut('fast');
}