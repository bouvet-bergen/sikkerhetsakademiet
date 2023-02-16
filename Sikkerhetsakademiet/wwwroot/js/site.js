const uri = 'api/Form';
let forms = [];

function processXML() {
    var message = document.getElementById('xmlmessage').value;

    var item = {
        message: message
    };

    fetch(uri + '/LoadXML', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then((data) => print(data));
}

function getItems() {
    fetch(uri + '/GetAllForms')
        .then(response => response.json())
        .then((data) => print(data));
}

function print(data) {
    let list = document.getElementById("formList");
    list.innerHTML = '';

    data.forEach((item) => {
        console.log('item: ' + item)
        let div = document.createElement("div");
        div.innerHTML = '<b>' + item.id + '</b>' + ' ' + item.name + ' ' + item.message;
        list.append(div);
    });
}

function addItem() {
    var name = document.getElementById('name').value;
    var message = document.getElementById('message').value;
    
    var item = {
        name: name,
        message: message
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
        })
        .catch(error => console.error('Unable to add item.', error));
}