(function () {
    angular
        .module("EricsAwesomeShop")
        .service("CarService", ['$resource', 'routeUrls',
            function ($resource, routeUrls) {
                // $resource(url, paramDefaults, actions, options)
                var CarApi = $resource(routeUrls.carApi,
                    {/* params */},
                    {/* custom actions */});
                this.post = function (car) {
                    new CarApi(car).$save(function (data) {
                        console.log(data);
                    });
                }
                this.query = function () {
                    return CarApi.query();
                };
        }]);
})();