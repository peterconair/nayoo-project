angular
  .module('stamplayApp', ['ngStamplay', 'MemberService'])
  .controller('MainController', MainController);
  
  
function MainController(Member) {
  
  var main = this;
  main.memberData = {};   // blank object to hold data from member form

  // ========================================
  // get all member
  // ========================================
  Member.getAll()
    .then(function(data) {
      main.memberList = data.instance;
    });

};
  

