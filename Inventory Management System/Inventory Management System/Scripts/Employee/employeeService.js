(function () {
    'use strict';
    angular.module('IMS')
        .service('EmployeeService', EmployeeService);

    EmployeeService.$inject = ['ApiFactory'];

    function EmployeeService(ApiFactory) {
        var employeeApi = new ApiFactory('Employee');
        var selectedRow = null;
        function setClickRow(index) {
            selectedRow = index;
        }
    }
})();