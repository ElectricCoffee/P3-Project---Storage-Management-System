// NOTE: ALL OF THE FOLLOWING METHODS RETURN A PROMISE
//       SEE https://docs.angularjs.org/api/ng/service/$http FOR MORE INFO

(function () {
    'use strict';
    angular.module('apiCommunication')
        .service('ApiFactory', ApiFactory);

    ApiFactory.$inject = ['$http'];

    function ApiFactory($http) {
        // controllerName is the name of the apiController in the uri
        // calling "new ApiFactory("Product")" for example, creates a link to /api/Product
        return function (controllerName) {
            var url = '/api/' + controllerName;
            this.post = post;
            this.get   = get;
            this.put = put;
            this.delete = del; // called remove instead of delete to not clash with the delete keyword

            // sends a post request to the server at the specified URL
            // this will create a new entry in the specified database
            function post(obj) {
                var temp = JSON.stringify(obj)
                return $http.post(url, temp);
            }

            // gets data from the server, if called without an argument it gets everything
            // get() = get everything
            // get(foo) = get everything witht he ID 'foo'
            function get(id) {
                var newUrl = id ? url + '/' + id : url;
                return $http.get(newUrl);
            }

            // updates an item with the specified id on the server
            // if neither data nor id exist, an error will be thrown
            function put(id, newData) {
                var newUrl = url + '/' + id;
                if (!id)
                    throw new URIError('An id was not provided', 'apiFactory.js');
                else if (!newData)
                    throw new URIError('No data was provided', 'apiFactory.js');
                else
                    return $http.put(newUrl, newData);
            }

            // delete an item with the specified id from the server
            // if the id isn't provided, an error will be thrown
            function del(id) {
                var newUrl = url + '/' + id;
                if (!id)
                    throw new URIError('An id was not provided', 'apiFactory.js');
                else
                    return $http.delete(newUrl);
            }
        };
    }
})();