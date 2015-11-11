/* Controllers implement the functionality required to control the view
 * If possible try and put the main logic into Services and Factories,
 * as this logic is likely to be reused in other Controllers
 */
(function () {
    'use strict';
    angular.module('messageSystem')
        .controller('MessageController', MessageController);

    MessageController.$inject = ['MessageService'];

    function MessageController(messageService) {
        var self = this; // make alias for this

        // expose the service
        self.service = messageService;
        self.sendMessage = sendMessage;

        // defines a simpler interface for sending messages within the view
        function sendMessage(sender, message) {
            var msg = {
                Sender: sender,
                Group: self.service.group,
                Message: message
            };

            console.log("sending message: " + JSON.stringify(msg));
            messageService.sendMessage(msg);
        }
    }
})();