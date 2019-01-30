
var app = angular.module("HomeEdit", []);

app.controller("HomeController", ($scope, $http) => {
    $scope.BuscaDados = (id) => {
        $http({
            method: "get",
            url: "/Home/Dados/" + id
        }).then(function (data) {
            $scope.lista = data.data;
            });
    };
    $scope.Editar = (dados) => {
        $http({
            method: "Post",
            url: "/Home/Editar",
            data: dados
        }).then(function () {
            window.location.reload();
        });
    };
    $scope.Deletar = (id) => {
        $http({
            method: "POST",
            url: "/Home/Deletar/"+id,
            dados: {}
        }).then(function () {
            alert("Registro " + id + " Foi excluido");
            window.location.reload();
        });
    };
});