'use strict';
app.service('webService', ['$location', function ($location) {
          
    this.getServiceBase = function () {
        var protocol = $location.protocol() + "://";
        var host = $location.host();
        var port = $location.port();

        var serviceBase;

        if (angular.isDefined(port)) {
            port = ":" + port;
            serviceBase = protocol + host + port + '/';
        }
        else {
            serviceBase = protocol + host + '/';
        }
        return serviceBase;       
    };

}]);