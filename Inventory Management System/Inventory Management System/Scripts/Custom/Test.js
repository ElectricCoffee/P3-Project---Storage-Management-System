(function() {
  var Message, app;

  Message = (function() {
    function Message(sender, message) {
      this.sender = sender;
      this.message = message;
    }

    return Message;

  })();

  app = angular.module('custom', ['SignalR']);

  app.controller('CustomController', function() {
    return this.greeting = 'Hello Angular';
  });

  app.factory('MessageService', [
    '$rootScope', 'Hub', '$timeout', function($rootScope, Hub, $timeout) {
      var Messages, hub;
      Messages = this;
      hub = new Hub('message', {
        listeners: {
          'displayMessage': function(sndr, msg) {
            return Message.push(sndr, msg);
          }
        },
        methods: ['sendMessage'],
        errorHandler: function(err) {
          return console.error(err);
        }
      });
      Messages.allMessages = [];
      Messages.push = function(s, m) {
        return Message.allMessages.push(new Message(s, m));
      };
      Messages.send = function(sndr, msg) {
        return hub.sendMessage(sndr, msg);
      };
      return Messages;
    }
  ]);

  app.controller('MessageController', [
    'MessageService', function(MessageService) {
      this.messages = MessageService.allMessages;
      return this.sendMessage = MessageService.send;
    }
  ]);

}).call(this);

//# sourceMappingURL=Test.js.map
