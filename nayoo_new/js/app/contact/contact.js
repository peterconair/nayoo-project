app.controller('ContactCtrl',  function($scope, $http, $modal ) { 
     
  $scope.ShowDlg =function(size)
  {  
    var modalInstance = $modal.open({
      animation: $scope.animationsEnabled,
      templateUrl: 'myModalContent.html',
      controller: 'ModalInstanceCtrl',
      size: size 
      }); 
  }; 
      
});

app.controller('ModalInstanceCtrl', function ($scope, $modalInstance) { 
  $scope.ok = function () {
    $modalInstance.close();
  };

  $scope.cancel = function () {
    $modalInstance.dismiss('cancel');
  };
});