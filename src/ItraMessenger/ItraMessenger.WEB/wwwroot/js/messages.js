var connection = new signalR.HubConnectionBuilder().withUrl("/messages").build();

connection.on("ReceiveMessage", function (senderName, title, body, date) {
    console.log("Message from " + senderName + window.location.toString());
    window.location.reload();
});

connection.on("SendToUnknownUser", function(recipientName){
    alert(`User ${recipientName} not registered. He will receive this message after first login.`)
});

connection.start().catch(function(error) {
    return console.error(error.toString());
});

$("#messageForm").validate({
    rules: {
        RecipientName: {
            required: true
        }
    },
    messages: {
        RecipientName: {
            required: "Please enter Recipient name"
        }
    },
    submitHandler: function(form) {
        var recipientName = document.getElementById("recipientName").value;
        var title = document.getElementById("messageTitle").value;
        var body = document.getElementById("messageBody").value;
        connection.invoke("SendMessage", recipientName, title, body).catch(function (error){
            console.error(error.toString());
        });
        console.log("Submited")
        form.submit();
    },
});