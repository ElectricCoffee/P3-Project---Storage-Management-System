(function () {
    'use strict';
    angular.module('IMS')
        .directive('searchBar', searchBar);

    function searchBar() {
        return {
            restrict: 'E',
            //scope: { type: '@', sender: '@' },
            //transclude: true,
            template:
                    '<div class="input-group">' + 
                        '<span class="input-group-addon glyphicon glyphicon-search"' + 
                              'aria-hidden="true" id="input-addon"></span>' + 
                        '<input ng-model="query" placeholder="search"' + 
                               'aria-describedby="input-addon" class="form-control">' + 
                    '</div>'
        };
    }
})();