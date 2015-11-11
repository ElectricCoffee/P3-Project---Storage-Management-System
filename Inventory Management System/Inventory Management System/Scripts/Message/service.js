/* Services are should contain the majority of the implementation
 * Services are intended to be shared among multiple controllers
 */
(function () {
    'use strict';
    angular.module('messageSystem')
        .service('MessageService', MessageService);

    MessageService.$inject = ['$rootScope', 'Hub'];

    function MessageService($rootScope, Hub) {
        var self = this;
        var hub = new Hub('message', {
            methods: ['sendMessage', 'joinGroup'],
            listeners: { 'displayMessage': displayMessage },
            errorHandler: console.error
        });

        // exposable functions
        self.allMessages = [];
        self.join = hub.joinGroup;
        self.push = self.allMessages.push;
        self.send = hub.sendMessage;

        // message is of the form {sender: ..., group: ..., message: ...}
        function displayMessage(message) {
            console.log('received message: ' + JSON.stringify(message));
            self.allMessages.push(message);
            $rootScope.$apply();
        }
    }
})();