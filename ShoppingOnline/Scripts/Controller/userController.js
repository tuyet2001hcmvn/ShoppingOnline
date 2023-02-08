var userController = {
    init: function () {
        userController.registerEvent();
    },

    registerEvent: function () {
        //$('#modalCreate').off('click').on('click', function () {
        //    userController.ResetForm();
        //});

        //$('#btnSave').click(function () {
        //    userController.Create();
        //});

        $('.btn-active').off('click').click(function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/User/ChangeStatus",
                data: { id: id },
                dataType: 'json',
                type: 'post',
                success: function (response) {
                    if (response.status)
                        btn.text('Kích hoạt');
                    else
                        btn.text('khóa');
                    window.location.reload(true);
                }
            });
        });
    },

    ConfirmPassword: function () {
        var password = $('#inputPassword').val();
        var confirm = $('#inputConfirm').val();

        if (confirm == password)
            userController.Create();
        else
            alert("Mật khẩu không trùng khớp!");
    },

    ResetForm: function () {
        $('#hidID').val('0');
        $('#inputName').val();
        $('#inputUsername').val();
        $('#inputPassword').val();
        $('#inputPhone').val();
        $('#chkStatus').prop('checked', true);
    },

    Create: function () {
        var name = $('#inputName').val();
        var username = $('#inputUsername').val();
        var password = $('#inputPassword').val();
        var phone = $('#inputPhone').val();
        var status = $('#chkStatus');
        var model = {
            Name: name,
            UserName: username,
            Password: password,
            Phone: phone,
            Status: status
        }
        $.ajax({
            url: '/Admin/User/Create',
            type: 'POST',
            data: model,
            success: function (response) {
                if (response.success) {
                    window.location.reload();
                }
            }
        });
    }
}

userController.init();