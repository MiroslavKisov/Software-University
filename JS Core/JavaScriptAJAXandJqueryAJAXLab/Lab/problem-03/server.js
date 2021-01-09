const express = require('express');

const app = express();

app.use(express.static('C:/SoftUni/JS Core/15. AJAX And JQuery AJAX/Lab/Solutions/problem-03/public'));

app.listen(3000, () => console.log('Listening on post 3000...'));