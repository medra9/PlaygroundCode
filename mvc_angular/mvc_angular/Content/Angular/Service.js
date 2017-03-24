app.service("myService", function ($http) {

    //getEmployees
    this.getEmployees = function () {
        var response = $http({
            method: 'POST',
            url: '/Home/GetEmployees'
        });
        return response;
    }

    //saveEmployees
    this.saveEmployees = function (employee) {
        var response = $http({
            method: 'POST',
            url: '/Home/Save',
            data: JSON.stringify(employee)
        });
    }

    //deleteEmployees
    this.deleteEmployees = function (emp) {
        var response = $http({
            method: 'POST',
            url: '/Home/Delete',
            data: JSON.stringify(emp),
        });
        return response;
    }

});