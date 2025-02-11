var app = angular.module("CadastroApp", []);

/*
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
*/

app.controller("UsuarioController", function ($scope, $http) {
    $scope.usuario = {};
    $scope.mensagem = "";

    $scope.salvarUsuario = function () {
        $http.post("/api/usuario/salvar", $scope.usuario)
            .then(function (response) {
                $scope.mensagem = response.data.Mensagem; // Agora a API retorna um JSON com a chave "Mensagem"
                $scope.usuario = {}; // Limpa os campos após salvar
            })
            .catch(function (error) {
                console.error("Erro na requisição:", error); // Log no console para depuração

                if (error.data && error.data.Mensagem) {
                    $scope.mensagem = "Erro ao salvar usuário: " + error.data.Mensagem;
                } else {
                    $scope.mensagem = "Erro ao salvar usuário. Tente novamente.";
                }
            });
    };
});