(function () {
    'use strict';
    angular.module('IMS')
        .controller('TableController', TableController);

    TableController.$inject = [];

    function TableController() {
        var self = this;
        self.selectedRow = 0;
        self.setClickedRow = setRow;

        function setRow(index) {
            self.selectedRow = index;
        }
    }
})();