(function() {
    'use strict';
    angular
        .module('custom', ['SignalR'])
        .service('MessageService', MessageService)
        .controller('CustomController', CustomController)
        .controller('MessageController', MessageController);

    // dependency injections
    MessageService.$inject = ['$rootScope', 'Hub', '$timeout'];
    MessageController.$inject = ['MessageService'];

    // constructors
    function CustomController() {
        this.greeting = 'hello, Angular.js!';
    }

    function Message(sender, message) {
        this.message = message;
        this.sender = sender;
    }

    function MessageService($rootScope, Hub, $timeout) {
        var self = this; // define alias
        var hub = new Hub('message', {
            // client-side methods
            listeners: { // listensers 'listen' for messages from the server
                'displayMessage': function (sndr, msg) {
                    pushMessage(sndr, msg);
                    $rootScope.$apply();
                }
            },
            // server-side methods
            methods: ['sendMessage'],
            errorHandler: err => console.error(err)
        });

        // Angular methods
        self.allMessages = []
        self.push = pushMessage;
        self.send = hub.sendMessage;

         function pushMessage (sndr, msg) {
            self.allMessages.push(new Message(sndr, msg));
        };
    }

    function MessageController(MessageService) {
        this.messages = MessageService.allMessages;
        this.sendMessage = MessageService.send;
    }
})();