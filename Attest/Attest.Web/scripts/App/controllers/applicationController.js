'use strict';
app.controller('applicationController', ['$scope', 'applicationService', '$location', '$filter', '$window', function ($scope, applicationService, $location, $filter, $window) {

    //$scope.certificationTypes = null;
    //$scope.certTypes = {};
        
    $scope.application = {};
    var isEdit = false;

    applicationService.getCertificationTypes().then(function (results) {
        $scope.certTypes = results.data;
             
        //edit application
        var app = null;        
        app = applicationService.getAppDetails();        
        
        //console.log($scope.certTypes[2]);

        if (app != null) {
            console.log('ready to update');
            isEdit = true;
            applicationService.clearAppDetails();
            $scope.application = app;

            var appDate, recpDate, sigDate = new Date();
            appDate = $filter('date')(app.applicationDate, 'yyyy-MM-dd');
            recpDate = $filter('date')(app.receiptDate, 'yyyy-MM-dd');
            sigDate = $filter('date')(app.signatureDate, 'yyyy-MM-dd');
           
            $scope.application.certificateTypeId = $scope.certTypes[app.certificateTypeId];
            $scope.application.applicationDate = new Date(appDate);
            $scope.application.receiptDate = new Date(recpDate);
            $scope.application.signatureDate = new Date(sigDate);           
        } else {
            console.log('ready to insert');
        }
    },   
    function (error) {
        //alert(error.data.message);
    });

    $scope.submitApplication = function () {
        var data = $scope.application;
        
        if (isEdit) {
            applicationService.updateApplication(data).then(function (response) {
                alert('successfully updated');
                isEdit = false;
                $location.path('/pendingApp');
            },
         function (err) {
             $scope.message = err.error_description;
             console.log(err.error_description);
         });
        } else {
            applicationService.submitApplication(data).then(function (response) {
                alert('successfully inserted');
                $location.path('/pendingApp');
            },
         function (err) {
             $scope.message = err.error_description;
             console.log(err.error_description);
         });
        }
        
    };

    $window.onload = function () {
        //$scope.application.certificateTypeId = ;
    };

}]);