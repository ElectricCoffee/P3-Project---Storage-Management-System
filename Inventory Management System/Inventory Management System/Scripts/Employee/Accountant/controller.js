(function () {
    'use strict';
    angular.module('IMS')
        .controller('AccountantController', AccountantController);

    // dependency injection
    AccountantController.$inject = ['EmployeeService'];

    // controller constructor
    function AccountantController(EmployeeService) {
        this.tableData = [];
    }
})();