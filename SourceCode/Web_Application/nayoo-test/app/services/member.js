angular
  .module('MemberService', [])
  .factory('Member', ['$q', '$stamplay', MemberService]);

function MemberService($q, $stamplay) {

  return {
    getAll: getAll
  };

  // get all the member
  function getAll() {
    var deferred = $q.defer();

    // use collection instead of model to grab all
    var memberCollection = $stamplay.Cobject('member').Collection;
    
    memberCollection.fetch()
      .then(function() {
        deferred.resolve(memberCollection);
      });

    return deferred.promise;
  }

}


