(function () {
    'use strict';
    angular.module('IMS')
        .service('EmployeeService', EmployeeService);

    EmployeeService.$inject = ['ApiFactory'];

    function EmployeeService(ApiFactory) {
        var employeeApi = new ApiFactory('Employee');
       this.setClickedRow = function setClickRow(index) {
            selectedRow = index;
        }
    }
})();