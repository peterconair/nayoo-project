

app.controller('GuestRecordCtrl', ['$scope', '$http', 'guest_records', '$stateParams', function ($scope, $http, guest_records, $stateParams) {
	
    
    guest_records.all().then(function (guest_records) {
        $scope.guest_records = guest_records;
	});
	
	$scope.Add = function()
	{
		var  opt_guest_record = {   
			carLicenseNo: "33333",
			houseNo: "123", 
			remark: "sample string 5",
			orgId: 6, 
			orgUniqueId:"kladklajdklasjdklasjkldjskl",
			createdBy: "1", 
			updatedBy: "1",  
			inDate: "2015-08-05T01:09:57.8888173+07:00",
			outDate: "2015-08-05T01:09:57.8888173+07:00" 
		};
		
		$http.post(serviceBase  +"RecordGuest", opt_guest_record).success(function(result){
			$scope.message="Success";
			guest_records.all().then(function (guest_records) {
				$scope.guest_records = guest_records;
				console.log("test");
			});
			console.log($scope.message);
			}).error(function(e){
			$scope.message = e.Message;
		}); 
		
		/*	$http.get(serviceBase  +"RecordGuest").success(function(result){
			$scope.message= result[0].carLicenseNo;
			}).error(function(e){
		$scope.message = e.message;
		});
		*/
	} 
	
	
}]);

