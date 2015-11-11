/* Services are should contain the majority of the implementation
 * Services are intended to be shared among multiple controllers
 */
(function () {
    'use strict';
    angular.module('messageSystem')
        .service('MessageService', MessageService);

    MessageService.$inject = ['$rootScope', '$http'];

    function MessageService($rootScope, $http) {
        // define aliases
        var self = this,
            message = $.connection.message, // define message hub
            hub = $.connection.hub;

        message.client.displayMessage = displayMessage;
        hub.start().done(hubDone);

        // exposable functions
        self.allMessages = [];
        self.group = null;
        self.sendMessage = message.server.sendMessage;

        // What the hub should do when done loading
        function hubDone() {
            $http.get('/api/message-group').then(httpSuccess, httpFailure);

            // what to do when the http GET succeeds
            function httpSuccess(response) {
                joinGroup(response.data);
            }

            // what to do when GET fails
            function httpFailure(response) {
                console.log(response.data);
            }
        }

        // behavior for joining a group
        function joinGroup(group) {
            console.log("joining group: " + JSON.stringify(group));
            self.group = group;
            message.server.joinGroup(group);
        }

        // Adds a message to the allMessages array. 
        // This array will hold the data 
        function displayMessage(msg) {
            console.log('received message: ' + JSON.stringify(msg));
            self.allMessages.push(msg);
            $rootScope.$apply();
        }

    }
})();