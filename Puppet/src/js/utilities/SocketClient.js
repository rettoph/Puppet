﻿class SocketClient
{
    constructor() {
        console.log('Creating new MessageHandler instance...');
        this.socket = new WebSocket("ws://" + window.location.hostname + ":8081");
        this.handlers = {};
        
        this.socket.addEventListener('message', this.handleRawMessage.bind(this));
    }

    bind(type, handler) {
        this.handlers[type] = handler;
    }

    send(data) {
        console.log('Sending Data', data);
        this.socket.send(JSON.stringify(data));
    }

    handleRawMessage(e) {
        var message = JSON.parse(e.data);
        this.handlers[message.type](message.data);
    }
}

module.exports = new SocketClient();