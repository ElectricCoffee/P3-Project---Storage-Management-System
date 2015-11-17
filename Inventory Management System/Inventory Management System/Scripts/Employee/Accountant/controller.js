(function () {
    'use strict';
    angular.module('IMS')
        .controller('AccountantController', AccountantController);

    AccountantController.$inject = ['EmployeeService'];

    function AccountantController(EmployeeService) {

    }
})();