const express = require('express');

const app = express();

app.use(express.static('C:/SoftUni/JS Core/15. AJAX And JQuery AJAX/Lab/Solutions/problem-02/public'));

app.listen(8888, () => console.log('Listening....'));