/// <reference path="../angular.js" />

var myApp = angular.module('myModule', []).controller('myController',
    function ($scope,$http) {

        //$http.get("webapi/employees")
        //    .then(function (response) {
        //        $scope.employees = response.data;
        //    });


        var employees = [
                {
                    name: "Ben", dateOfBirth: new Date("November 23, 1980"),
                    gender: 1, salary: 55000.788
                },
                {
                    name: "Sara", dateOfBirth: new Date("May 05, 1970"),
                    gender: 0, salary: 68000
                },
                {
                    name: "Mark", dateOfBirth: new Date("August 15, 1974"),
                    gender: 1, salary: 57000
                },
                {
                    name: "Pam", dateOfBirth: new Date("October 27, 1979"),
                    gender: 0, salary: 53000
                },
                {
                    name: "Todd", dateOfBirth: new Date("December 30, 1983"),
                    gender:1, salary: 60000
                }
            ];

        var countries = [
            {
                name: "UK",
                cities: [
                    { name: "London" },
                    { name: "Birmingham" },
                    { name: "Manchester" }
                ]
            },
            {
                name: "USA",
                cities: [
                    { name: "Los Angeles" },
                    { name: "Chicago" },
                    { name: "Houston" }
                ]
            },
            {
                name: "India",
                cities: [
                    { name: "Hyderabad" },
                    { name: "Chennai" },
                    { name: "Mumbai" }
                ]
            }
        ];

        var technologies = [
            { name: "C#", likes: 0, dislikes: 0 },
            { name: "ASP.NET", likes: 0, dislikes: 0 },
            { name: "SQL", likes: 0, dislikes: 0 },
            { name: "AngularJS", likes: 0, dislikes: 0 }
        ];

        // very good logic for sorting
        $scope.sortData = function (column) {
            $scope.reverseSort = ($scope.sortColumn == column) ?
                !$scope.reverseSort : false;
            $scope.sortColumn = column;
        }

        $scope.getSortClass = function (column) {

            if ($scope.sortColumn == column) {
                return $scope.reverseSort? 'arrow-down': 'arrow-up';
            }

            return '';
        }


        $scope.technologies = technologies;

        $scope.incrementLikes = function (technology) {
            technology.likes++;
        };

        $scope.incrementDislikes = function (technology) {
            technology.dislikes++;
        };

        $scope.countries = countries;
        $scope.employees = employees;
        $scope.rowCount = 5;
        $scope.sortColumn = "name";
        $scope.reverseSort = false;

        $scope.employeeView = "employeeTable.html"; //http://csharp-video-tutorials.blogspot.com/2015/11/ng-include-directive-in-angularjs.html

    });