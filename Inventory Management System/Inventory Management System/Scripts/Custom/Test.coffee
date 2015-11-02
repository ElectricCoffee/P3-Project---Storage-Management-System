# CoffeeScript

class Message
    constructor: (@sender, @message) ->

app = angular.module 'custom', ['SignalR']
app.controller 'CustomController', ->
    @greeting = 'Hello Angular'
    
app.factory 'MessageService', ['$rootScope', 'Hub', '$timeout', ($rootScope, Hub, $timeout) ->
    Messages = this
    
    hub = new Hub 'message',
        # client-side methods
        listeners: 
            'displayMessage': (sndr, msg) -> Message.push sndr, msg
        # server-side methods
        methods: ['sendMessage']
        errorHandler: (err) -> console.error err
    
    # angular methods
    Messages.allMessages = []
    Messages.push = (s, m) ->
        Message.allMessages.push new Message s, m
    Messages.send = (sndr, msg) -> hub.sendMessage sndr, msg
    
    Messages
]

app.controller 'MessageController', ['MessageService', (MessageService) ->
    
]