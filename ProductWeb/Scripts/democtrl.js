angular.module('demoapp', ['ngRoute', 'ui.bootstrap'])
.controller('democtrl', function ($scope, $http, $modal) {

    $scope.category = [{ Id: 0, text: 'Select' }, { Id: 7, text: 'Laptop' }, { Id: 8, text: 'DSLR Cameras' }, { Id: 9, text: 'Pendrives' }]
    $scope.status = [{ text: 'Select' }, { text: 'In Stock' }, { text: 'Out Of Stock' }, { text: 'BackOrder' }];
    $scope.defaultstatus = $scope.status[0];
    $scope.defaultcategory = $scope.category[0].Id;
    $scope.submitted = false;
    $scope.gap = 5;
    $scope.currentPage = 0;
    $scope.itemsperpage = 10;
    $scope.filteredproducts = [];
    $scope.addProduct = function () {

        if ($scope.formCreate.$valid) {

            //$scope.product.push({ categoryid: $scope.defaultcategory }, { name: $scope.newproductname }, { description: $scope.newdescription }, { price: $scope.newprice }, { status: $scope.defaultstatus });
            alert("Here");
            var data = { Name: $scope.newproductname, Description: $scope.newdescription, Category: { CategoryId: $scope.defaultcategory }, Price: $scope.newprice, Status: $scope.defaultstatus.text }
            //$scope.product.Name = $scope.newproductname;
            //$scope.product.Description = $scope.newdescription;
            //$scope.product.Category = {};
            //$scope.product.Category.CategoryId = $scope.defaultcategory;
            //$scope.product.Price = $scope.newprice;
            //$scope.product.Status = $scope.defaultstatus.text;


            $http.post('api/Product', data).success(function () {
                alert("success");
            }).error(function () {
                alert("error");
            });
        }
        else {
            alert("ERRRRRRRRRR");
            $scope.submitted = true;

        }


    };
    $http.get('api/Product').success(function (data) {

        //$scope.product = {};

        $scope.productsglobal = data;
        //var begin = (($scope.currentPage) * $scope.itemsperpage);
        //var end = begin + $scope.itemsperpage;
        ////console.log(end);
        //$scope.filteredproducts = $scope.productsglobal.ProductList.slice(begin, end);
        //console.log($scope.filteredproducts);
        $scope.setPage($scope.currentPage);
        $scope.pagedItems = function () {

            return Math.ceil($scope.productsglobal.ProductList.length / $scope.itemsperpage);


        };
    }).error(function () {
        alert("error")
    });
    //$scope.getProduct = function () {
    
   
    $scope.range = function (size, start, end) {
        var ret = [];
        //console.log(size);
       // console.log(start);
        //console.log(end);
        //console.log(size, start, end);

        if (size < end) {
            end = size;
            start = size - $scope.gap;
        }
        for (var i = start; i < end; i++) {
            ret.push(i);
        }
       // console.log(ret);
        return ret;
    };
    $scope.prevPage = function () {
        if ($scope.currentPage > 0) {
            $scope.currentPage--;
            $scope.setPage($scope.currentPage);
        }
    };

    $scope.nextPage = function () {
        if ($scope.currentPage < $scope.pagedItems() - 1) {
            $scope.currentPage++;
            $scope.setPage($scope.currentPage);
        }
    };
    $scope.setPage = function (n) {
        $scope.currentPage = n;
        console.log("current page " + $scope.currentPage + "n value  " + n);
        var begin = "";
        var end = "";
        //  $scope.range($scope.pagedItems, $scope.currentPage, $scope.currentPage + 5);
        begin = (($scope.currentPage) * $scope.itemsperpage);
        end = begin + $scope.itemsperpage;
        console.log(begin);
        console.log(end);
        $scope.filteredproducts = $scope.productsglobal.ProductList.slice(begin, end);
        console.log($scope.filteredproducts);
    };
    

    //};
    $scope.deleteProduct = function (productid) {

        //var data = { Id: productid };
        $http.delete('api/Product/' + productid).success(function () {

            alert("Delete");

        }).error(function () {

            alert("Error");
        });
    };
    $scope.openProduct = function (product) {

        var modalInstance = $modal.open({
            templateUrl: 'myModalContent.html',
            controller: ModalInstanceCtrl,
            resolve: {
                items: function () {
                    product.currentStatus = { text: product.Status };
                    console.log(product);
                    return product;
                    //console.log(product);
                }
            }
        });

    };
});;
var ModalInstanceCtrl = function ($scope, $modalInstance, items, $http) {

    $scope.item = items;
    console.log($scope.item);
    $scope.category = [{ Id: 7, text: 'Laptop' }, { Id: 8, text: 'DSLR Cameras' }, { Id: 9, text: 'Pendrives' }];
    $scope.status = [{ Id: 0, text: 'In Stock' }, { Id: 1, text: 'Out of Stock' }, { Id: 2, text: 'Back Order' }];

    angular.forEach($scope.status, function (stat) {
        if (items.currentStatus.text == stat.text) {
            $scope.item.currentStatus = stat;
        }
    });


    //$scope.CategoryId = items.Category.CategoryId;
    //$scope.CategoryName = items.Category.CategoryName;
    //$scope.Name = items.Name;
    //$scope.Description = items.Description;
    //$scope.Price = items.Price;
    //$scope.Status = items.Status;

    $scope.save = function () {
        var data = { Id: $scope.item.Id, Name: $scope.item.Name, Description: $scope.item.Description, Category: { CategoryId: $scope.item.Category.CategoryId }, Price: $scope.item.Price, Status: $scope.item.currentStatus.text }

        console.log(data);
        $http.put('api/Product', data).success(function () {
            alert("success");
            $scope.cancel();
        }).error(function () {
            alert("error");
        });

    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
};

