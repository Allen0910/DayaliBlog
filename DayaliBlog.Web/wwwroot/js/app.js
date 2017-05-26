var app = angular.module("myApp", ['ngSanitize']);//要想不转义html,则需要引入ngSanitize插件
app.controller("secondController", function ($scope, $http) {
    $http.get('/Home/GetList').then(function (result) {  //正确请求成功时处理  
        $scope.blogs = result.data;
        console.info(result);
    }).catch(function (result) { //捕捉错误处理  
        console.info(result);
    });
});
app.controller("firstController", function ($scope, $http) {
    $http.get('/Home/CategLog').then(function (result) {  //正确请求成功时处理  
        $scope.categs = result.data;
        console.info(result);
    }).catch(function (result) { //捕捉错误处理  
        console.info(result);
    });
});