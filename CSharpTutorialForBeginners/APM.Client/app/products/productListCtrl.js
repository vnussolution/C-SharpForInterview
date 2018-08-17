(function () {
    "use strict";
    angular
        .module("productManagement")
        .controller("ProductListCtrl",['productResource',ProductListCtrl]);

    function ProductListCtrl(productResource) {
        var vm = this;

        vm.searchCriteria = "TBX";
        vm.sortProperty = 'Price';
        vm.sortDirection = 'desc';
        vm.filter = `startswith(ProductCode, '${vm.searchCriteria}') or startswith(ProductName,'${vm.searchCriteria}')`,


        

        productResource.query({
            $filter: vm.filter,   
            $orderby:vm.sortProperty+ ' '+ vm.sortDirection
        }, function (data) {
            vm.products = data;
            console.log('data ', data);
            });

        vm.getList = function ()
        {
            productResource.query({
                $filter: `startswith(ProductCode, '${vm.searchCriteria}') or startswith(ProductName,'${vm.searchCriteria}')`,
                $orderby: vm.sortProperty + ' ' + vm.sortDirection
            }, function (data) {
                vm.products = data;
                console.log('data ', data);
            });    
        }

    }
}());
