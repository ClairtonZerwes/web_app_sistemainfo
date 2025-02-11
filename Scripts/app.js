var app = angular.module("CadastroApp", []);

app.controller("UsuarioController", function ($scope, $http) {
    $scope.usuario = {};
    $scope.mensagem = "";

    $scope.salvarUsuario = function () {
        $http.post("/api/usuario/salvar", $scope.usuario)
            .then(function (response) {
                $scope.mensagem = response.data;
                $scope.usuario = {};
            }, function (error) {
                $scope.mensagem = "Erro ao salvar usuário: " + error.data;
            });
    };
});


