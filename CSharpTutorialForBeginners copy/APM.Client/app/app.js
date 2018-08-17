(function () {
    "use strict";

    var app = angular.module("productManagement", ['common.services']);

    app.controller('IndexCtrl', ['$rootScope', 'userAccount', 'currentUser', IndexCtrl]);

    function IndexCtrl($rootScope, userAccount, currentUser) {
        var vm = this;
        vm.isLoggedIn = function () { return currentUser.getProfile().isLoggedIn;}
        vm.message = '';
        vm.userData = { userName: '', email: 'frank@frank.com', password: 'Frank1@', confirmPassword: '' };



        vm.view = 'app/products/productEditView.html';
        $rootScope.id = 5;

        vm.selectProduct = function (id) {
            $rootScope.id = id;
            vm.view = 'app/products/productEditView.html';
        }

        vm.registerUser = function () {
            vm.userData.confirmPassword = vm.userData.password;
            userAccount.registration.registerUser(vm.userData,
                function (data) {
                    vm.userData.confirmPassword = '';
                    vm.message = '...Registration successful';
                    vm.login();
                },
                function (response) {
                    vm.message = response.statusText + "\r\n";
                    if (response.data.modelState) {
                        for (var key in response.data.modelState) {
                            vm.message += response.data.modelState[key] + "\r\n";
                        }
                    }
                    if (response.data.exceptionMessage)
                        vm.message += response.data.exceptionMessage;
                }
            );
        }

        vm.login = function () {
            vm.userData.grant_type = 'password';
            vm.userData.userName = vm.userData.email;

            userAccount.login.loginUser(vm.userData, function (data) {
                vm.message = '';
                vm.userData.password = '';
                currentUser.setProfile(vm.userData.userName, data.access_token);
            },
                function (response) {
                    vm.password = '';
                    vm.message = response.statusText + "\r\n";

                    if (response.data.exceptionMessage)
                        vm.message += response.data.exceptionMessage;


                    if (response.data.error) {
                        vm.message += response.data.error;
                    }
                }
            )
        }

    }

}());