app.controller('GuestRecordCtrl', function ($scope, $http, $modal) {
  
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
});


