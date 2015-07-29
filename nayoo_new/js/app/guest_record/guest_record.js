
app.controller('GuestRecordCtrl', ['$scope', '$http', function($scope, $http) {

  $http.get('js/app/note/notes.json').then(function (resp) {
    $scope.notes = resp.data.notes;
    // set default note
    $scope.note = $scope.notes[0];
    $scope.notes[0].selected = true;
  });

  $scope.colors = ['primary', 'info', 'success', 'warning', 'danger', 'dark'];


}]);