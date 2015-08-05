app.controller('GuestRecordCtrl', ['$scope', '$http', '$stateParams',
                                   function ($scope, $http, $stateParams) {

       
                                       
        $scope.Binding = function () {
            ajaxindicatorstart("");
            $http.get(serviceBase + "RecordGuest").success(function (result) {
                $scope.guest_records = result;
                ajaxindicatorstop();
            }).error(function (e) {
                $scope.message = e.message;
                ajaxindicatorstop();
            });
        };

        $scope.Add = function (Guest) { 
          var opt_guest_record = {
                carLicenseNo:  Guest.carLicenseNo,
                houseNo:  Guest.houseNo,
                remark: Guest.Remark,
                orgId:  orgId,
                orgUniqueId: orgUniqueId,
                createdBy: "1",
                updatedBy: "1" 
            }; 

            $http.post(serviceBase + "RecordGuest", opt_guest_record).success(function (result) {
                $scope.Binding(); 
				$scope.formReset(Guest);
            }).error(function (e) {
                $scope.message = e.Message;
            }); 
        };
        
		$scope.formReset=function(form){
			 angular.copy({},form);
		};
		
        $scope.Binding();


}]);
