(function () {
    angular
        .module('EricsAwesomeShop', ['ngRoute', 'ngResource'])
        .config(function ($routeProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: '/angular/views/home.html',
                    controller: 'HomeController',
                    controllerAs: 'self'
                })
                .when('/login', {
                    templateUrl: '/angular/views/login.html',
                    controller: 'LoginController',
                    controllerAs: 'self'
                })
                .when('/admin', {
                    templateUrl: '/angular/views/admin.html',
                    controller: 'AdminController',
                    controllerAs: 'self'
                });
                //.otherwise({
                //    templateUrl: '/angular/views/404.html',
                //    controller: 'FourOhFourController',
                //    controllerAs: 'self'
                //});
        });
})();