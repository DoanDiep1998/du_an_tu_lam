// hiển thị ảnh
var loadFile = function (event) {
    var show_input = "";
    var file = document.getElementById('fileInput');
    // đọc chiều dài trong mảng ảnh đưa vào
    for (var i = 0; i < file.files.length; i++) {
        show_input += '<img src="" id="' + i + 'img" width="75" height="75" class="form-group" />'// lặp và đưa Id vào
    }

    // hiển thị số thẻ ảnh theo số ảnh
    $('#show_img').html(show_input);
    for (var i = 0; i < file.files.length; i++) {
        // thêm Url cho từng thẻ ảnh
        var output = document.getElementById('' + i + 'img');// mỗi một lần lặp lấy ra Id  và truyền Url theo Id đó
        output.src = URL.createObjectURL(event.target.files[i]);
    }

};
//check Use
function checkUse(Use) {
    $.ajax({
        type: 'POST',
        url: '/Customers/CheckUser',
        data: {
            'use': Use,

        }, success: function (res) {
            if (res == "success") {
                $('#checkUse').empty();
                $('#checkUse').attr('style', 'color:aqua');
                $('#checkUse').html("Bạn có thể dùng tài khoản này!");
                $('.Btn-Save').attr('id', 'Btn-Save');
            } else {
                $('#checkUse').empty();
                $('#checkUse').attr('style', 'color:red');
                $('#checkUse').html("Tài khoản trùng lặp");
                $('.Btn-Save').removeAttr('id');
            }
        }
    });
}
//check email
function checkEmail(Email) {
    $.ajax({
        type: 'POST',
        url: '/Customers/CheckEmail',
        data: {
            'email': Email,

        }, success: function (res) {
            if (res == "success") {

                $('#checkEmail').empty();
                $('#checkEmail').attr('style', 'color:aqua');
                $('#checkEmail').html("Bạn có thể dùng Email này!");
                $('.Btn-Save').attr('id', 'Btn-Save');
            } else {
                $('#checkEmail').empty();
                $('#checkEmail').attr('style', 'color:red');
                $('#checkEmail').html("Email này đã được đăng kí");
                $('.Btn-Save').removeAttr('id');
            }
        }
    });
}
function Create(data) {
    $.ajax({
        type: "POST",
        url: "/Customers/Creates",
        data: data,
        contentType: false, // không  header
        processData: false,// ko sử lý dữ liệu
        success: function (res) {
            if (res == "success") {

                $('#res').attr('class', 'bg-success text-white')
                $('#res').html("Bạn đã đăng ký tài khoản thành công")
            } else if (res == "errorEmail") {
                $('#checkEmail').attr('style', 'color:red');
                $('#checkEmail').html("Email này đã được đăng kí");
            } else if (res == "errruse") {
                $('#checkUse').attr('style', 'color:red');
                $('#checkUse').html("Tài khoản trùng lặp");
            } else {
                $('#res').attr('class', 'bg-danger text-white"')
                $('#res').html("Đăng kí lỗi, vui lòng kiểm tra lại các ô nhập liệu!")
            }
        }
    });
}
$(function () {
    // check Use and Email
    $('.Use').keyup(function () {

        var use = $('.Use').val();
        checkUse(use)

    })
    $('.Email').keyup(function () {

        var email = $('.Email').val();
        checkEmail(email)
    })
    //thêm mới 
    $('#Btn-Save').click(function () {

        if ($('.Phone').val().length == 10) {
            if (window.FormData != undefined) {
                var data = new FormData();
                //lấy đối tượng upload file
                var Upfile = [];
                var Upfile = document.getElementById('fileInput');
                data.append('fileUp', Upfile.files[0]);
                data.append('CustomerName', $('.CustomerName').val());
                data.append('Email', $('.Email').val());
                data.append('Gender', $('.Gender').val());
                data.append('Birthday', $('.Birthday').val());
                data.append('Phone', $('.Phone').val());
                data.append('Address', $('.Address').val());
                data.append('User', $('.Use').val());
                data.append('Password', $('.Password').val());
                Create(data);
            } else {
                alert('trình duyệt không hỗ trợ bảng, vui lòng chọn trình duyệt khác!!');
            }
        } else {
            alert("số điện thoại phải là 10 số!!")
        }
    })
});
// đăng nhập
function Login(data) {
    $.ajax({
        type: 'Post',
        url: '/Customers/Login',
        data: data,
        success: function (res) {
            if (res == "error") {
                $('#loginMsg').text('sai tài khoản hoặc mật khẩu');
            } else {
                location.reload();
            }
        }
    });
}
// kiểm tra đăng nhập
$(function () {

    $('#btnLogin').click(function () {
        var use = $('#use').val(),
            pass = $('#pass').val();
        if (use != "" && pass != "") {
            data = {
                'use': $('#use').val(),
                'pass': $('#pass').val()
            }
            Login(data);
        } else {
            alert('vui lòng điền đủ thông tin!');
        }

    })

}); 