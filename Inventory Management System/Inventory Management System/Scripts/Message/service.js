/* Services are should contain the majority of the implementation
 * Services are intended to be shared among multiple controllers
 */
(function () {
    'use strict';
    angular.module('messageSystem')
        .service('MessageService', MessageService);

    MessageService.$inject = ['$rootScope', 'Hub', '$timeout'];

    function MessageService($rootScope, Hub, $timeout) {
        var self = this;
        var hub = new Hub('message', {
            methods: ['sendMessage'],
            listeners: { 'displayMessage': displayMessage },
            errorHandler: console.error
        });

        // exposable functions
        self.allMessages = [];
        self.push = pushMessage;
        self.send = hub.sendMessage;

        // convenience functions
        function pushMessage(sender, message) {
            self.allMessages.push(new Message(sender, message));
        }

        function displayMessage(sender, message) {
            pushMessage(sender, message);
            $rootScope.$apply();
        }

        function Message(sender, message) {
            this.sender = sender;
            this.message = message;
        }
    }
})();