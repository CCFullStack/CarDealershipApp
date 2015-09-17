(function () {
    angular
        .module('EricsAwesomeShop')
        .controller('AdminController', function (CarService) {
            var self = this;
            this.addCar = function () {
                CarService.post(self.newCar);
            };
        });
})();