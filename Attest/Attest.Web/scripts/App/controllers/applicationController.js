'use strict';
app.controller('applicationController', ['$scope', 'applicationFactory', function ($scope, applicationFactory) {

    //console.log(webService.getServiceBase());
    $scope.orders = [];

    applicationFactory.getCertificateTypes().then(function (results) {

        console.log(results.data);

    }, function (error) {
        //alert(error.data.message);
    })();

}]);