(function () {
    'use strict';
    angular.module('IMS')
        .service('EmployeeService', EmployeeService);

    EmployeeService.$inject = ['ApiFactory'];

    function EmployeeService(ApiFactory) {
        var self = this;
        var employeeApi = new ApiFactory('Employee');
        self.selectedRow = 0;
        self.setClickedRow = setClickRow;

        function setClickRow(index) {
            self.selectedRow = index;

        }
    }
})();