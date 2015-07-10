angular
  .module('MemberService', [])
  .factory('Member', ['$q', '$stamplay', MemberService]);

function MemberService($q, $stamplay) {

  return {
    create: create,
    getAll: getAll
  };

  function create(data) {
    var deferred = $q.defer();

    var memberModel = $stamplay.Cobject('member').Model;
    
    memberModel.set('owner','559deef30e1c836454ab5a46');
    memberModel.set('name',data.name);

    memberModel.save()
       .then(function() {

          deferred.resolve(memberModel);
       });
    return deferred.promise;

  }

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


