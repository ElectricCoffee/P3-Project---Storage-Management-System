(function () {
    'use strict';
    angular.module('IMS')
        .controller('InventoryController', InventoryController);

    InventoryController.$inject = ['EmployeeService'];

    function InventoryController(EmployeeService) {

    }
})();