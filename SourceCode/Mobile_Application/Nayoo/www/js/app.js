var nayooApp = angular.module('nayooApp', ['ui.router'])

nayooApp.config(function($stateProvider, $urlRouterProvider) {
    
    $urlRouterProvider.otherwise('/login');
    
    $stateProvider
        .state('loginState', {
            url: '/login',
            templateUrl: 'template/login.html'
        })
        .state('menuState', {
            url: '/menu',
            templateUrl: 'template/menu.html'
        });
        
});

var menuApp = angular.module('menuApp', ['ui.router'])

menuApp.config(function($stateProvider, $urlRouterProvider) {
    
    $urlRouterProvider.otherwise('/guest');
    
    $stateProvider
        .state('guestState', {
            url: '/guest',
            templateUrl: 'template/guest.html'
        });
        
});