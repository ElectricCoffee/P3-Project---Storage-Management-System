(function () {
    'use strict';
    angular.module('IMS')
        .controller('AccountantController', AccountantController);

    // dependency injection
    AccountantController.$inject = ['EmployeeService'];

    // controller constructor
    function AccountantController(EmployeeService) {
        var self = this;
        self.tableData = [];
        self.getTableData = getTableData;

        function getTableData() {
            EmployeeService.productApi.read().then(success, failure);

            function success(response) {
                console.log("successfully fetched data");
                self.tableData = response.data;
            }

            function failure(response) {
                console.error("failed to fetch data");
                console.error(response.data);
            }
        }
    }
})();