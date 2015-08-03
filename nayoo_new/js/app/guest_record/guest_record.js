app.controller('GuestRecordCtrl', ['$scope', '$http', 'guest_records', '$stateParams', function ($scope, $http, guest_records, $stateParams) {

    $http.get('js/app/note/notes.json').then(function (resp) {
        $scope.notes = resp.data.notes;
        // set default note
        $scope.note = $scope.notes[0];
        $scope.notes[0].selected = true;
    });

    $scope.colors = ['primary', 'info', 'success', 'warning', 'danger', 'dark'];

    $scope.fold = $stateParams.fold;
    
    guest_records.all().then(function (guest_records) {
        $scope.guest_records = guest_records;
    });



}]);


