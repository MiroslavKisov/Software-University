function attachEvents() {

    let submitButton = $('#submit').on('click', sendMessage);
    let refreshButton = $('#refresh').on('click', showMessages);
    let url = ``;

    function sendMessage() {
        let authorName = $('#author').val();
        let msgText = $('#content').val();

        let currentMessage = {
            
            author: authorName,
            content: msgText,
            timestamp: Date.now(),    
        }

        $.ajax({
            method : 'POST',
            url : url,
            data : JSON.stringify(currentMessage),
        });
    }

    function showMessages() {
        
        $.ajax({
            method: 'GET',
            url : url,
            success : displayMessages
        });

        function displayMessages(data) {
            let messages = Object.entries(data);
            let messagesArea = $('#messages');

            messages.sort((a,b) => b[1].timestamp - a[1].timestamp);
            let message = ``;

            for(const messageInfo of messages) {

                message += `${messageInfo[1].author}: ${messageInfo[1].content}\n`;
            }

            messagesArea.text(message);
        }
    }
}
