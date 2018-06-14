//recommend use of Angular2+ or ReactJS instead of jQuery

$(document).ready(function () {

    //when the Show All Orders button is clicked, function is run
    $('#getAllOrders').click(function () {
        var $orders = $('#orders');
        if (!$orders.hasClass('emptyDiv')) {
            $orders.text('');
            $orders.addClass('emptyDiv');
            $('#orderTitle').addClass('hide');
        }
        //gets all orders for display via promise interface
        $.get("/web/api/order", function (data) {
            if (data.length) {
                $.each(data, function () {
                    var $orderPanel = $('<div class="panel panel-default" />');
                    var orderTotal = this.OrderTotal.toFixed(2);
                    var $div = $('<div class="panel-heading" />').text(this.Description)
                        .appendTo($orderPanel);

                    var $productList = $('<ul class="list-group" />');

                    $.each(this.OrderProducts, function (j) {
                        var amount = this.OrderPrice.toFixed(2);
                        var $li = $('<li class="list-group-item" />').text(this.ProductName)
                            .appendTo($productList);
                        var $span = $('<span class="pull-right" />').text(this.Quantity + ' @ $' + amount + '/ea')
                            .appendTo($li);
                    });

                    var $liTotal = $('<li class="list-group-item" />').text('Total: ')
                        .appendTo($productList);
                    var $spanTotal = $('<span class="pull-right" />').text('$' + orderTotal)
                        .appendTo($liTotal);

                    $productList.appendTo($orderPanel);
                    $orders.append($orderPanel);
                });
            }
            else {
                toastr.warning("No orders to display - make sure the order ID is valid.");
            }
        })
            //will run if successful - pop up success message
            .done(function (data) {
                if (data.length) {
                    $('#orderTitle').removeClass('hide');
                    $orders.removeClass('emptyDiv');
                    toastr.success("Success!");
                }
            })
            //will run if failed - pop up error message
            .fail(function () {
                toastr.error("Error: Unable to get orders", {
                    "timeOut": "0",
                    "extendedTImeout": "0"
                });
            })
            .always(function () {
                //load a message that always displays regardless of success or failure
            });
    });

    //if input order ID button is clicked, following function runs
    $('#orderIDInputBtn').click(function () {
        var $orders = $('#orders');
        if (!$orders.hasClass('emptyDiv')) {
            $orders.text('');
            $orders.addClass('emptyDiv');
            $('#orderTitle').addClass('hide');
        }
        var $inputVal = $('#orderIDInput').val();
        var urlString = '/web/api/order/GetOrderById/' + $inputVal;

        //get uses promise interface, attempt to call api and retrieve orders with this ID
        $.get(urlString, function (data) {
            if (data.length) {
                $.each(data, function () {
                    var $orderPanel = $('<div class="panel panel-default" />');
                    var orderTotal = this.OrderTotal.toFixed(2);
                    var $div = $('<div class="panel-heading" />').text(this.Description)
                        .appendTo($orderPanel);

                    var $productList = $('<ul class="list-group" />');

                    $.each(this.OrderProducts, function (j) {
                        var amount = this.OrderPrice.toFixed(2);
                        var $li = $('<li class="list-group-item" />').text(this.ProductName)
                            .appendTo($productList);
                        var $span = $('<span class="pull-right" />').text(this.Quantity + ' @ $' + amount + '/ea')
                            .appendTo($li);
                    });

                    var $liTotal = $('<li class="list-group-item" />').text('Total: ')
                        .appendTo($productList);
                    var $spanTotal = $('<span class="pull-right" />').text('$' + orderTotal)
                        .appendTo($liTotal);

                    $productList.appendTo($orderPanel);
                    $orders.append($orderPanel);
                });
            }
            else {
                toastr.warning("No orders to display - make sure the order ID is valid.");
            }
        })
            //will run if successful - pop up success message
            .done(function (data) {
                if (data.length) {
                    $('#orderTitle').removeClass('hide');
                    $orders.removeClass('emptyDiv');
                    toastr.success("Success!");
                }
            })
            //will run if failed - pop up error message
            .fail(function () {
                toastr.error("Error: Unable to get orders", {
                    "timeOut": "0",
                    "extendedTImeout": "0"
                });
            })
            .always(function () {
                //load a message that always displays regardless of success or failure
            });
    });

    //clear out orders displayed, hide title, clear the search input value
    $('#clearOrders').click(function () {
        if (!$('#orders').hasClass('emptyDiv')) {
            var $ordersDiv = $('#orders');
            $ordersDiv.text('');
            $ordersDiv.addClass('emptyDiv');
            $('#orderTitle').addClass('hide');
            toastr.info("Orders cleared");
        }
        $('#orderIDInput').val('');
    });
});