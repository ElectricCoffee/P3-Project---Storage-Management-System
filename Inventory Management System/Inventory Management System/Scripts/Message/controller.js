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
        this.getMessageQueue = getMessages;
        this.messages = messageService.allMessages;
        this.pushMessage = messageService.push;
        this.sendMessage = messageService.send;

        function getMessages() { // temporary definition
            return $resource('/api/Message').query();
        }
    }
})();