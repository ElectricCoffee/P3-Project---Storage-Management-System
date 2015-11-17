(function () {
    'use strict';
    angular.module('IMS')
        .service('EmployeeService', EmployeeService);

    EmployeeService.$inject = ['ApiFactory'];

    function EmployeeService(ApiFactory) {
        this.employeeApi = new ApiFactory('Employee');
        this.productApi  = new ApiFactory('Product');
    }
})();