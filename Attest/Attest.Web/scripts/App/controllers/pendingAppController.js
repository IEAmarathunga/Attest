'use strict';
app.controller('pendingAppController', ['$scope', '$http', 'applicationService', '$q', '$location', function ($scope, $http, applicationService, $q, $location) {

    applicationService.getPendingAppsForMsg().then(function (results) {
        $scope.pendingApps = results.data;
       
    }, function (error) {
        //alert(error.data.message);
    });

    $scope.EditApplication = function (id) {
                
        applicationService.EditApplication(id).then(function (response) {            
            $location.path('/application');
        },
         function (err) {
             $scope.message = err.error_description;
             console.log(err.error_description);
         });
    };

    $scope.SendMessage = function (id) {

        applicationService.SendMessage(id).then(function (response) {
            alert("Message has been sent");
        },
         function (err) {
             $scope.message = err.error_description;
             console.log(err.error_description);
         });
    };

}]);