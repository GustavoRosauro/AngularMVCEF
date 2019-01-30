var app = angular.module("Homeapp", []);

app.controller("HomeController", function ($scope, $http) {
    $scope.btntext = "save";
    $scope.MudaPagina = () => {
        window.location = "Home/ExibiDados";
    };
    $scope.savedata = function () {
        $scope.btntext = "please wait.....";
        $http({
            method:"POST",
            url: "/Home/Nome/",
            data: $scope.register
        }).then(function (d) {
            alert(d.data);
            window.location.reload();
        });
    };
});