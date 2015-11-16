(function () {
    'use strict';
    angular.module('apiCommunication')
        .service('ApiFactory', ApiFactory);

    ApiFactory.$inject = ["$http"];

    function ApiFactory($http) {
        return function (controllerName) {
            var url = '/api/' + controllerName;
            this.create = post;
            this.read   = get;
            this.update = put;
            this.delete = del;

            function post(obj) {
                $http.post(url, obj);
            }

            function get(id) {
                var newUrl = id ? url + "/" + id : url;
                return $http.get(newUrl);
            }

            function put(id, newData) {
                var newUrl = url + "/" + id;
                if (!id) console.error("An id was not provided");
                else if (!newData) console.error("no data was provided");
                else return $http.put(newUrl, newData);
            }

            function del(id) {
                var newUrl = url + "/" + id;
                if (!id) console.error("An id was not provided");
                else return $http.delete(newUrl);
            }
        };
    }
})();