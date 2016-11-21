var payment = {
    init: function () {
        payment.getLoginUser();
        payment.registerEvent();
    },
    registerEvent: function () {
        $('#forminfo').validate({
            rules: {
                full_name: "required",
                address: "required",
                phone: "required",
                email: {
                    required: true,
                    email: true
                },
                province_id: "required"
            },
            messages: {
                full_name: "Nhập họ tên",
                address: "Nhập địa chỉ",
                phone: "Nhập số điện thoại",
                email: {
                    required: "Bạn cần nhập email",
                    email: "Định dạng email chưa đúng"
                }
            }
        });

        $('.btn-checkout').off('click').on('click', function () {
            var isValid = $('#forminfo').valid();
            if (isValid) {
                payment.payMent();
            }
            else {
                $('.summary').show();
            }
        });
    },
    getLoginUser: function () {
        $.ajax({
            url: '/Carts/GetUser',
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var user = response.data;
                    $('.user-login').hide();
                    $('.color-blue').hide();
                    $('#txtName').val(user.Name);
                    $('#txtAddress').val(user.Address);
                    $('#txtEmail').val(user.Email);
                    $('#txtPhone').val(user.Phone);
                    $('#txtEmail').attr('readonly', true);
                }
            }
        });
    },
    payMent: function () {
        var PaymentMethod = $("input:radio:checked").next().text();
        var order = {
            ID: 0,
            CustomerName: $('#txtName').val(),
            CustomerAddress: $('#txtAddress').val(),
            CustomerEmail: $('#txtEmail').val(),
            CustomerMobile: $('#txtPhone').val(),
            CustomerMessage: $('#txtMessage').val(),
            PaymentMethod: PaymentMethod,
            PaymentStatus: false,
            Status: false
        };
        $.ajax({
            url: '/Carts/CreateOrder',
            type: 'POST',
            dataType: 'json',
            data: {
                orderViewModel: JSON.stringify(order)
            },
            success: function (response) {

                if (response.status) {
                    alert('Gởi đơn hàng thành công. Chúng tôi sẽ liên hệ sớm nhất.');
                    window.location.href = "/";
                }
                else {
                    //alert('Có lỗi xảy ra.');
                    window.location.href = "/Carts/ThanhToanTT";
                }
            }
        });
    }
}
payment.init();
