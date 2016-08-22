var app = angular.module('AttestApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/App/Views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/App/Views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/App/Views/signup.html"
    });

    $routeProvider.when("/application", {
        controller: "applicationController",
        templateUrl: "/App/Views/application.html"
    });

    $routeProvider.when("/pendingApp", {
        controller: "pendingAppController",
        templateUrl: "/App/Views/pendingApplications.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});

app.constant('ngSettings', function ($location) {
    var protocol = $location.protocol() + "://";
    var host = $location.host();
    var port = $location.port();
    var apiServiceBaseUri;

    if (angular.isDefined(port)) {
        port = ":" + port;
        this.apiServiceBaseUri = protocol + host + port + '/';
    }
    else {
        this.apiServiceBaseUri = protocol + host + '/';
    }
});

//app.constant('ngSettings', {
//    apiServiceBaseUri: serviceBase,
//});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});