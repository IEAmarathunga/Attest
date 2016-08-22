'use strict';
app.controller('pendingAppController', ['$scope','$http', function ($scope, $http) {

    $scope.pendingApps = [{
        AppNo: "A123",
        Date: "2015-05-05",
        For: "Birth",
        Name: "IE Amarathunga",
        Address: "118/4 Galkanuwa Rd, Gorakana, Moratuwa.",
        Mobile: "075-9360576",
        Fee: "250",
        Receipt:"DFG46532"
    },
    {
        AppNo: "A456",
        Date: "2015-05-05",
        For: "Birth",
        Name: "Asela",
        Address: "Panadura",
        Mobile: "075-9360576",
        Fee: "250",
        Receipt: "DFG46532"
    },
    {
        AppNo: "A456",
        Date: "2015-05-05",
        For: "Birth",
        Name: "Tharindu",
        Address: "Panadura",
        Mobile: "075-9360576",
        Fee: "250",
        Receipt: "DFG46532"
    }
    ];

}]);