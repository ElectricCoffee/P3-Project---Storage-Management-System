(function () {
    'use strict';
    angular.module('IMS')
        .service('EmployeeService', EmployeeService);

    EmployeeService.$inject = ['ApiFactory'];

    function EmployeeService(ApiFactory) {
        var self = this;
        var employeeApi = new ApiFactory('Employee');
       self.selectedRow = null;
       self.setClickedRow = function setClickRow(index) {
            self.selectedRow = index;
        }
    }
})();