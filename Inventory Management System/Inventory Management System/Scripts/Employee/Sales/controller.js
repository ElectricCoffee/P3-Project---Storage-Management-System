(function () {
    'use strict';
    angular.module('IMS')
        .controller('SalesController', SalesController);

    SalesController.$inject = ['EmployeeService'];

    function SalesController(EmployeeService) {

    }
})();