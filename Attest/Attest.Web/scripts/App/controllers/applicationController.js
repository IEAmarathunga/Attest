'use strict';
app.controller('applicationController', ['$scope', 'applicationService', '$location', function ($scope, applicationService, $location) {

    $scope.certificationTypes = null;
    $scope.certTypes = [];
        
    var app = applicationService.getAppDetails();    
    console.log(app);
    $scope.application = app;
    console.log($scope.application);

    applicationService.getCertificationTypes().then(function (results) {
        $scope.certTypes = results.data;
        //$scope.certificationTypes = "Birth";
    }, function (error) {
        //alert(error.data.message);
    });

    $scope.submitApplication = function () {

        applicationService.submitApplication($scope.application).then(function (response) {
            alert('success');
            $location.path('/pendingApp');
        },
         function (err) {
             $scope.message = err.error_description;
             console.log(err.error_description);
         });
    };

}]);