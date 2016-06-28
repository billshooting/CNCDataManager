var controllers = angular.module('controllers', []);
controllers.controller('CNCWorkingConditionCtrl', function ($scope) {
    $scope.submitForm = function (isValid) {
        if (isValid) {
            alert('yes');
        }
    };
});

controllers.controller('CNCSystemTable', function ($scope,$http) {
    $http.get('././././App_Data/NCSystem.json')
      .success(function (response) {
          $scope.NCSystems = response.data;
      });
});
