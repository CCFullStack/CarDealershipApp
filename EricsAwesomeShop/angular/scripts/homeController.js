(function () {
    angular
        .module('EricsAwesomeShop')
        .controller('HomeController', function (CarService) {
            this.allCars = CarService.query();

            
        });
})();