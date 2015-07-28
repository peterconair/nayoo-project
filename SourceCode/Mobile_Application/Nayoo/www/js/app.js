angular.module('ionicApp', ['ionic'])
  
 .controller('AppCtrl', function() {

  ionic.Platform.ready(function() {
    navigator.splashscreen.hide();
  });

 });
 
angular.module('ionicApp', ['ionic'])

.config(function($stateProvider, $urlRouterProvider) {

  $stateProvider
    .state('tabs', {
      url: "/tab",
      abstract: true,
      templateUrl: "templates/tabs.html"
    })
    .state('tabs.home', {
      url: "/home",
      views: {
        'home-tab': {
          templateUrl: "templates/home.html",
          controller: 'HomeTabCtrl'
        }
      }
    })
    .state('tabs.about', {
      url: "/about",
      views: {
        'home-tab': {
          templateUrl: "templates/about.html"
        }
      }
    })


   $urlRouterProvider.otherwise("/tab/home");

})

.controller('HomeTabCtrl', function($scope) {
  console.log('HomeTabCtrl');
});
              