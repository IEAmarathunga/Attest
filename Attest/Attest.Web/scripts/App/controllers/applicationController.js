'use strict';
app.controller('applicationController', ['$scope', 'applicationService', function ($scope, applicationService) {

    $scope.certificationTypes = null;
    $scope.certTypes = [];
    

    applicationService.getCertificationTypes().then(function (results) {
        $scope.certTypes = results.data;
        $scope.certificationTypes = "Birth";
    }, function (error) {
        //alert(error.data.message);
    });

    $scope.submitApplication = function () {

        applicationService.submitApplication($scope.application).then(function (response) {
            alert('success');
        },
         function (err) {
             $scope.message = err.error_description;
             console.log(err.error_description);
         });
    };

}]);