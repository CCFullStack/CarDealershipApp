(function () {
    angular
        .module('EricsAwesomeShop')
        .controller('LoginController', function ($location, $http) {
            var self = this;
            self.login = function () {
                $http.post('/token', "grant_type=password&username=" + self.username + "&password=" + self.password,
                    {
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        }
                    })
                    .success(function (data) {
                        token = data.access_token;
                        $http.defaults.headers.common.Authorization = 'Bearer ' + token;
                        $location.path('/admin');
                    })
                    .error(function () {
                        console.error('Error logging in.');
                    });
            };
        });
})();