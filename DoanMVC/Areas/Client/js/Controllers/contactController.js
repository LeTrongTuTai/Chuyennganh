var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('#frmContact').validate({
            rules: {
                name: "required",
                email: {
                    required: true,
                    email: true
                },
                phone: {
                    required: true,
                    number: true
                },
                message: "required"
            },
            messages: {
                name: "Yêu cầu nhập tên",
                message: "Yêu cầu nhập nội dung",
                email: {
                    required: "Bạn cần nhập email",
                    email: "Định dạng email chưa đúng"
                },
                phone: {
                    required: "Số điện thoại được yêu cầu",
                    number: "Số điện thoại phải là số."
                }
            }
        });

        $('#btnSend').off('click').on('click', function (e) {
            e.preventDefault();
            var isValid = $('#frmContact').valid();
            if (isValid) {
                contact.createContact();
            }
        });       
    },
    resetForm: function () {
        $('#ContactFormName').val('');
        $('#ContactFormPhone').val('');
        $('#ContactFormEmail').val('');
        $('#ContactFormMessage').val('');
    },
    createContact: function () {
        var contact = {
            Name: $('#ContactFormName').val(),
            Phone: $('#ContactFormPhone').val(),
            Email: $('#ContactFormEmail').val(),
            Content: $('#ContactFormMessage').val(),           
            Status: false
        }
        $.ajax({
            url: '/Contact/Send',
            type: 'POST',
            dataType: 'json',
            data: {
                feebackViewModel: JSON.stringify(contact)
            },
            success: function (response) {

                if (response.status) {
                    alert('Gởi phản hồi thành công');
                    $('#ContactFormName').val('');
                    $('#ContactFormPhone').val('');
                    $('#ContactFormEmail').val('');
                    $('#ContactFormMessage').val('');
                }
                else {
                    $('#contactResult').show();
                    $('#contactResult').text(response.message);
                }
            }
        });
    }
}
contact.init();