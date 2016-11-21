var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        
        $('#btnPayment').off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = "/thanh-toan.html";
        });
        $('#btnContinue').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Carts/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang.html";
                    }
                }
            })
        });
        $('.cart__remove').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Carts/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang.html";
                    }
                }
            })
        });
    }
}
cart.init();