'use strict';
app.controller('applicationController', ['$scope', 'applicationService', '$location', '$filter', function ($scope, applicationService, $location, $filter) {

    $scope.certificationTypes = null;
    $scope.certTypes = [];
        
    $scope.application = {};

    applicationService.getCertificationTypes().then(function (results) {
        $scope.certTypes = results.data;
        //$scope.certificationTypes = "Birth";
    }, function (error) {
        //alert(error.data.message);
    });

    var app = applicationService.getAppDetails();
    console.log(JSON.stringify(app));
    $scope.application = app;
    applicationService.clearAppDetails();

    //$scope.application.applicationDate = "2016-06-15";

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
       
    $scope.$watch('applicationDate', function (newValue) {
        $scope.application.applicationDate = $filter('date')(newValue, 'YYYY/MM/DD');
});

    $scope.$watch('application.applicationDate', function (newValue) {
        $scope.application.applicationDate = $filter('date')(newValue, 'YYYY/MM/DD');
});

}]);