// our module IMS relies on the Api-Communication and Messaging-System modules.
(function () {
    'use strict';
    angular.module('IMS', ['apiCommunication', 'messageSystem','ngRoute']);
})();