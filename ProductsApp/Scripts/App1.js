
var uri = 'api/Orders';

$(document).ready(function () {
    GetSalespeople();
    GetStores();
});

function GetMarkupData() {
    // Send an AJAX request
    $.getJSON(uri + '/BestMarkups')
        .done(function (data) {

            $.each(data, function (key, item) {

                $('<li>', { text: formatItem(item) }).appendTo($('#markups'));
            });
        });
}

function formatItem(item) {
    return 'City : ' + item.City + ', Count: ' + item.Count;
}

function GetSalespeople() {
    // Send an AJAX request
    $.getJSON(uri + '/Salespeople')
        .done(function (data) {

            $.each(data, function (key, item) {

                $('<option>', { text: item, value: item }).appendTo($('#employees'));
            });
        });
}

function GetStores() {
    // Send an AJAX request
    $.getJSON(uri + '/Stores')
        .done(function (data) {

            $.each(data, function (key, item) {

                $('<option>', { text: item, value: item }).appendTo($('#stores'));
            });
        });
}

function GetEmployeePerformance() {
    let select = document.getElementById("employees");
    let employeeName = select.options[select.selectedIndex].value;
    console.log(employeeName);

    // Send an AJAX request
    $.getJSON(uri + '/EmployeePerformance?employeeName=' + employeeName)
        .done(function (data) {
            console.log(data);

            document.getElementById("employeePerformance").innerText = "That employee sold $" + data + " for the year";
        });
}

function GetStorePerformance() {
    let select = document.getElementById("stores");
    let storeName = select.options[select.selectedIndex].value;
    console.log(storeName);

    // Send an AJAX request
    $.getJSON(uri + '/StorePerformance?storeCity=' + storeName)
        .done(function (data) {
            console.log(data);

            document.getElementById("storePerformance").innerText = "That store sold $" + data + " for the year";
        });
}