// A RESTful factory for retreiving mails from 'mails.json'
app.factory('guest_records', ['$http', function ($http) {
    ajaxindicatorstart("");
    var guest_records = $http.get("http://nayooapi.chabatech.com/api/RecordGuest/Get").then(function (resp) {
    
    //console.log(resp.data);
    ajaxindicatorstop();
    return resp.data;
});


var factory = {}; factory.all = function () {
return guest_records;
}; factory.get = function (id) {
return guest_records.then(function (guest_records) {
    for (var i = 0; i < guest_records.length; i++) {
        if (guest_records[i].id == id) return guest_records[i];
    }
    return null;
})
};
return factory;
}]);
