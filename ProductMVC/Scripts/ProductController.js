angular.module('Productapp', ['ngRoute', 'ui.bootstrap'])
.controller('ProductController', function ($scope, $http, $modal) {

    //$scope.new = [{ Id: 0, text: 'Select' }, { Id: 5, text: 'Nokia' }, { Id: 6, text: 'Samsung' }, { Id: 7, text: 'Apple' }, 
    //    { Id: 8, text: 'Dell' },{ Id: 9, text: 'Acer' },{ Id: 10, text: 'HP' },{ Id: 11, text: 'Canon' },{ Id: 12, text: 'Nikon' },
    //{ Id: 13, text: 'Sharp' }, { Id: 14, text: 'Sony' }]
    //console.log($scope.new);

    $http.get('api/Product/SubCategories').success(function (data)
    {
        
        alert("In subcategories");
        
        $scope.category = data;
        
        //$scope.newcategory = data.CategoryList;
        ////var default = data.CategoryList[0];
        ////console($scope.defaultcategory);
        //console.log($scope.newcategory);
        //$scope.new = function ()
        //{
        //    var defaultcategory = new function () {
        //        this.CategoryId = 0;
        //        this.CategoryName = 'Select';
               
        //    }
        //    $scope.newcategory = $scope.newcategory.splice(0, 0, defaultcategory);
        //    console.log($scope.newcategory);
        //}
        //console.log($scope.newcategory);
        //angular.forEach($scope.category.CategoryList[0], function (value, index) {
        //    console(value.CategoryName);
        //})
        //angular.forEach($scope.category.CategoryList, function (value, key) {
        //    $scope.categoryarray = [];
        //    $scope.newcategory += [{ Id: value.CategoryId, text: value.CategoryName }];
        //    $scope.categoryarray.push($scope.newcategory);
            
        //})
      
        //console.log($scope.categoryarray);
    }).error(function(){

        alert("Error while loading Categries");

    });

    
    $scope.status = [{ text: 'Select' }, { text: 'In Stock' }, { text: 'Out Of Stock' }, { text: 'BackOrder' }];
    $scope.defaultstatus = $scope.status[0];
    //$scope.defaultcategory = [{ CategoryId: 0, CategoryName: 'Select' }];
    //console.log("Default"+$scope.defaultcategory);
    
   // $scope.defaultcategory = [{ text: 'Select' }];
    //console($scope.defaultcategory);
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
             $http.post('api/Product', data).success(function () {
                alert("successfully created product");
            }).error(function () {
                alert("error while creating product");
            });
        }
        else {
            alert("ERROR Form is Invalid");
            $scope.submitted = true;

        }


    };
    $http.get('api/Product/GetAllProducts').success(function (data) {

        
        alert("Get PRoducts");
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
        alert("error in products")
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
        //console.log("current page " + $scope.currentPage + "n value  " + n);
        var begin = "";
        var end = "";
        //  $scope.range($scope.pagedItems, $scope.currentPage, $scope.currentPage + 5);
        begin = (($scope.currentPage) * $scope.itemsperpage);
        end = begin + $scope.itemsperpage;
        //console.log(begin);
        // console.log(end);
        //console.log($scope.productsglobal);
        //$scope.new = $scope.productsglobal.ProductList;
        //console.log($scope.new);
        $scope.filteredproducts = $scope.productsglobal.ProductList.slice(begin, end);
        //console.log($scope.filteredproducts);
    };
    

    //};
    $scope.deleteProduct = function (productid) {

        //var data = { Id: productid };
        $http.delete('api/Product/' + productid).success(function () {

            alert("Deleting products");

        }).error(function () {

            alert("Error while deleting");
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
    $scope.category = [{ Id: 0, text: 'Select' }, { Id: 5, text: 'Nokia' }, { Id: 6, text: 'Samsung' }, { Id: 7, text: 'Apple' },
      { Id: 8, text: 'Dell' }, { Id: 9, text: 'Acer' }, { Id: 10, text: 'HP' }, { Id: 11, text: 'Canon' }, { Id: 12, text: 'Nikon' },
  { Id: 13, text: 'Sharp' }, { Id: 14, text: 'Sony' }]

    $scope.status = [{ Id: 0, text: 'In Stock' }, { Id: 1, text: 'Out of Stock' }, { Id: 2, text: 'Back Order' }];

    angular.forEach($scope.status, function (stat) {
        if (items.currentStatus.text == stat.text) {
            $scope.item.currentStatus = stat;
        }
    });


    $scope.save = function () {
        var data = { Id: $scope.item.Id, Name: $scope.item.Name, Description: $scope.item.Description, Category: { CategoryId: $scope.item.Category.CategoryId }, Price: $scope.item.Price, Status: $scope.item.currentStatus.text }

        console.log(data);
        $http.put('api/Product', data).success(function () {
            alert("successfully updated product");
            $scope.cancel();
        }).error(function () {
            alert("error while updating product");
        });

    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
};

