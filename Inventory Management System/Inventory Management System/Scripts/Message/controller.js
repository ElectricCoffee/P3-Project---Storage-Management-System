/* Controllers implement the functionality required to control the view
 * If possible try and put the main logic into Services and Factories,
 * as this logic is likely to be reused in other Controllers
 */
(function () {
    'use strict';
    angular.module('messageSystem')
        .controller('MessageController', MessageController);

    MessageController.$inject = ['MessageService', '$resource'];

    function MessageController(messageService, $resource) {
        var self = this;

        self.service = messageService;

        self.getMessageQueue = getMessages;
        self.messages        = messageService.allMessages;
        self.sendMessage     = sendMessage;

        function getMessages() { // temporary definition
            return $resource('/api/Message').query();
        }

        function joinGroup(groupName) {
            console.log('joining group: ' + groupName);
            messageService.join(groupName);
            self.group = groupName;
        }

        function sendMessage(sender, message) {
            var msg = {
                Sender: sender,
                Group: self.service.group,
                Message: message
            };

            console.log(msg);
            messageService.sendMessage(msg);
        }
    }
})();