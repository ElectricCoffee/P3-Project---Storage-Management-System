/* Services are should contain the majority of the implementation
 * Services are intended to be shared among multiple controllers
 */
(function () {
    'use strict';
    angular.module('messageSystem')
        .service('MessageService', MessageService);

    MessageService.$inject = ['$rootScope', '$resource'];

    function MessageService($rootScope, $resource) {
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
        //self.joinGroup = message.server.joinGroup;
        //self.done = hub.start().done;
        //self.start = start;

        function hubStart() {
            // do stuff on start
        }

        function hubDone() {
            self.group = $resource('/api/message-group').get();
            message.server.joinGroup(self.group);
        }

        //function start(group) {
        //    self.group = group;
        //    hub.start().done(hubDone);
        //}

        //function joinGroup(group) {
        //    console.log("joining group: " + group);
        //    self.group = group;
        //    message.server.joinGroup(group);
        //}

        function displayMessage(msg) {
            console.log('received message: ' + JSON.stringify(msg));
            self.allMessages.push(msg);
            $rootScope.$apply();
        }

    }
})();