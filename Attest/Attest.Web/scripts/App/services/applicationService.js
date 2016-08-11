'use strict';
app.factory('applicationService', ['$http', function ($http) {

    //var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';
    var protocol = $location.protocol() + "://";
    var host = $location.host();
    var port = $location.port();

    if (angular.isDefined(port)) {
        port = ":" + port;
        this.serviceBase = protocol + host + port + '/';
    }
    else {
        this.serviceBase = protocol + host + '/';
    }
    var applicationsServiceFactory = {};

    var _getapplications = function () {

        return $http.get(serviceBase + 'api/Application').then(function (results) {
            return results;
        });
    };

    applicationsServiceFactory.getapplications = _getapplications;

    return applicationsServiceFactory;

}]);