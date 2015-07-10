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

  main.submitMember = function(formData) {
     
     Member.create(formData)
        .then(function(data) {

           main.memberData = {};

           Member.getAll()
              .then(function(data) {
                 main.memberList = data.instance;
              });
        });
  };

};
  

