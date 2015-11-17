(function () {
    'use strict';
    angular.module('IMS')
        .controller('TechnicianController', TechnicianController);

    TechnicianController.$inject = ['EmployeeService'];

    function TechnicianController(EmployeeService) {

    }
})();