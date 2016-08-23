'use strict';
app.factory('applicationService', ['$http', '$q', 'webService', function ($http, $q, webService) {

    var serviceBase = webService.getServiceBase();

    var appServiceFactory = {};

    var _getCertificationTypes = function () {
                
        return $http({
            method: 'GET',
            dataType: 'application/json',
            url: serviceBase + 'api/Master/CertificateType'            
        }).success(function (result) {
            return result;
        })
    };

    var _submitApplication = function (application) {

        var data = JSON.stringify(application);
        console.log(application);
        var deferred = $q.defer();
        $http.post(webService.getServiceBase() + 'api/Application/PostApp', data, {
            headers: { 'Content-Type': 'application/json' }
        }).success(function (response) {
                        
            deferred.resolve(response);

        }).error(function (err, status) {            
            deferred.reject(err);
            console.log(JSON.stringify(err) + " and sts is " + status);
        });

        return deferred.promise;

    };

    appServiceFactory.getCertificationTypes = _getCertificationTypes;
    appServiceFactory.submitApplication = _submitApplication;

    return appServiceFactory;

}]);