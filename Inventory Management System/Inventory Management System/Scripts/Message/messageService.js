/* Services are should contain the majority of the implementation
 * Services are intended to be shared among multiple controllers
 */
(function () {
    'use strict';
    angular.module('messageSystem')
        .factory('MessageService', MessageService);

    MessageService.$inject = ['$rootScope'];

    function MessageService($rootScope) {
        var self    = this,
            message = $.connection.message,
            hub     = $.connection.hub;
        
        //message.on('displayMessage', displayMessage);
        message.client.displayMessage = displayMessage;

        //hub.start(hubStart);
        hub.start().done(hubDone);

        // exposable functions
        self.group = null;
        self.allMessages = [];

        self.sendMessage = message.server.sendMessage;
        self.joinGroup = joinGroup;

        function hubStart() {
            // do stuff on start
        }

        function hubDone() {
            //message.server.joinGroup("testGroup");
            // do stuff on connection done
            console.log("I'm done.");
        }

        function joinGroup(group) {
            console.log("joining group: " + group);
            self.group = group;
            message.server.joinGroup(group);
        }

        function displayMessage(msg) {
            console.log('received message: ' + JSON.stringify(msg));
            self.allMessages.push(msg);
            $rootScope.$apply();
        }

    }
})();