app.controller('HomeCtrl', function ($scope, myService) {
    GetAllEmployee();

    function GetAllEmployee(){
        var getData = myService.getEmployees();
        getData.then(function (emp){
            $scope.employees = emp.data.employees;
            angular.forEach($scope.employees, function (obj) {
                obj["showEdit"] = true;
            });
        }, function(error){
            console.log(error.data);
        });
    }

    $scope.toggleEdit = function (emp) {
        emp.showEdit = emp.showEdit ? false : true;
        if (emp.showEdit) {
            var employee = {
                ID: emp.ID,
                FirstName: emp.FirstName,
                LastName: emp.LastName,
                Country: emp.Country
            };
            var saveData = myService.saveEmployees(employee);
            saveData.then(function(response){
                alert(response.data);
            });
        }
    };

    $scope.delete = function (emp) {
        var deleteData = myService.deleteEmployees(emp);
        deleteData.then(function (response) {
            $scope.employees.splice(emp.ID, 1);
            $scope.refresh();
            alert(response.data);
        });
    };

    $scope.addRow = function () {
        $scope.employees.push({
            'ID': $scope.employees.ID,
            'FirstName': $scope.employees.FirstName,
            'LastName': $scope.employees.LastName,
            'Country': $scope.employees.Country
        });
        $scope.employees.ID = '';
        $scope.employees.FirstName = '';
        $scope.employees.LastName = '';
        $scope.employees.Country = '';
    };

});