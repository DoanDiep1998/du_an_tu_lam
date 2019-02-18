$(function () {
    function lay_Gio_Hang() {
        return JSON.parse(sessionStorage.getItem('gio_hang') || '[]');
    }
    function them_Gio_Hang(item) {
        var gh = lay_Gio_Hang();
        var ton_tai = gh.filter(x => x.id == item.id);
        if (ton_tai.length) {// nếu đã có thì cập nhập số lượng
            ton_tai[0].quantitysp += item.quantitysp;
        } else {
            gh.push(item);// chưa có thì thêm vào

        }
        luu_Lai(gh);

    }
    function luu_Lai(gh) {
        sessionStorage.setItem('gio_hang', JSON.stringify(gh));
    }
    function sl_sp() {
        var gh = lay_Gio_Hang();
        // map để lấy ra trường  trong mảng, giống foreach
        var mapgh = gh.map(function (item) { return item.quantitysp; });
        // reduce rút gọn và cộng các phần tử vừa map được( link xem hàm reduce )
        //https://developer.mozilla.org/vi/docs/Web/JavaScript/Reference/Global_Objects/Array/Reduce?fbclid=IwAR2SFn0QuKW__qMLUYLQ6VpUQePg_6nV4P09dHy3fN-z1BGqLynGHdbZImw
        return mapgh.reduce(function (a, b) { return a + b; }, 0);

    }
    function tong_tien() {
        var gh = lay_Gio_Hang();

        var tongtien = gh.map(function (item) {
            if (item.pricesale < item.price && item.pricesale != 0) {
                return (item.quantitysp * item.pricesale);
            } else {
                return (item.quantitysp * item.price);
            }
        });
        return tongtien.reduce(function (a, b) { return a + b }, 0);
    }
    function thongbao() {
        var gh = lay_Gio_Hang();
        if (gh.length == 0) {
            $('.thong_bao_rong').empty();
            $('.thong_bao_rong').attr('style', 'color:Red');
            $('.thong_bao_rong').text("Đơn hàng trống!");

        } else {
            $('.thong_bao_rong').empty();
            $('.thong_bao_rong').text("Đơn hàng");
        }
    };


    $('.btn-addproduct').on('click', function (evt) {
        // evt.target là sử lý khi có một thẻ DOM được click vào (ở đây là các nút Thêm vào giỏ hàng)

        let add = $(evt.target),

            //lấy ra các data
            idsp = add.data('id'),
            namesp = add.data('name'),
            pricesp = add.data('price'),
            pricesalesp = add.data('pricesale'),
            picturesp = add.data('pictureshow');
        if (idsp && pricesp) {
            them_Gio_Hang({ id: idsp, name: namesp, price: pricesp, pricesale: pricesalesp, picture: picturesp, quantitysp: 1 });
            $('.qty').text(sl_sp());
            $('.total').html(tong_tien().toLocaleString('vi-VN', { useGrouping: true }) + '<sup>đ</sup>');
        }


    });

    function hien_thi_gio_hang() {
        var gh = lay_Gio_Hang();
        $('#hienthidanhsachsp').empty();
        gh.forEach(function (item) {
            $('#hienthidanhsachsp').append(`<tr>
										<td class="thumb"><img src="${item.picture}" alt=""></td>
										<td class="details">
											<a href="">${item.name}</a>
											<ul>
												
											</ul>
										</td>
										<td class="price text-center"><strong>${(item.pricesale < item.price && item.pricesale != 0 ? item.pricesale : item.price).toLocaleString('vi-VN', { useGrouping: true })}<sup>đ</sup></strong></td>
										<td class="qtysp text-center"><input class="input quantitysp" data-idsp='${item.id}' type="number" value="${item.quantitysp}"></td>
										<td class="price text-center"><strong class="primary-color">${ item.pricesale < item.price && item.pricesale != 0 ? (item.pricesale * item.quantitysp).toLocaleString('vi-VN', { useGrouping: true }) : (item.price * item.quantitysp).toLocaleString('vi-VN', { useGrouping: true })}<sup>đ</sup></strong></td>
										<td class="text-right"><a class="main-btn icon-btn delete_sp"   href='javascript: void(0)' data-idspd="${item.id}"><span class="fa fa-close" data-idspd="${item.id}"></span></a></td>
									</tr>`);
        });
        //xóa sản phẩm
        $('.delete_sp').on('click', function (evt) {


            let gh = lay_Gio_Hang(),
                input = $(evt.target),
                idsp = input.data('idspd'),
                sanpham = gh.find(f => f.id == idsp),// tìm kiếm sản phẩm
                index = gh.indexOf(sanpham);// indexOf tìm kiếm giá trị và trả về vị trí của phần tử đó. Nếu ko tìm thấy kết quả trả về là -1

            if (index > -1) {
                //splice(chỉ số cần xóa, số phần tử cần xóa, phần tử cần thêm'ở đây không có ')
                gh.splice(index, 1);// truyền chỉ số cần xóa trong mảng
            }

            luu_Lai(gh);
            hien_thi_gio_hang();


        });
        //cập nhật số lượng
        $('.quantitysp').on('change', function (evt) {
            let gh = lay_Gio_Hang(),
                input = $(evt.target),
                idsp = input.data('idsp'),
                soluong = Number(input.val()),
                sp = gh.find(x => x.id == idsp);
            if (100 <= soluong || soluong <= 0) {
                $('.quantitysp').val(1);
                alert('số lượng giới hạn từ 1 tới 99');
                soluong = $('.quantitysp').val();

            }
            if (soluong % 2 != 0) {
                //floor để lấy giá trị nguyên truyền vào
                soluong = Math.floor(soluong);
            }
            if (sp && soluong && soluong != null && soluong > 0 && soluong < 100) {
                sp.quantitysp = soluong;
                luu_Lai(gh);
                hien_thi_gio_hang();
            }


        });
        //kiểm tra giỏ hàng rỗng
        thongbao();

        // hiển thị tổng tiền
        $('.total').html(tong_tien().toLocaleString('vi-VN', { useGrouping: true }) + '<sup>đ</sup>');
        // hiển thị tổng số lượng
        $('.qty').text(sl_sp());

    };
    hien_thi_gio_hang();

    $('.xem_gio_hang').on('click', function (evt) {
        let gh = lay_Gio_Hang();
        if (gh.length == 0) {

            alert('Giỏ hàng rỗng!');
            evt.preventDefault();
            return false;
        }
    })
    $('.thanh_toan').on('click', function () {
        var namec = $('.namec').val(),
            Emailc = $('.Emailc').val(),
            phonec = $('.phonec').val(),
            paymentc = $('.paymentc').val(),
            Transportc = $('.Transportc').val(),
            addressc = $('.addressc').val(),
            commentc = $('.commentc').val(),
            totalmonney = tong_tien(),
            sanphams = lay_Gio_Hang();
        if (namec == "") {
            alert('tên trống');
        } else if (Emailc == "") {
            alert("email trống")
        } else if (phonec == "") {
            alert("số điện thoại trống")
        } else if (addressc == "") {
            alert("địa chỉ trống")
        } else if (phonec.length != 10) {
            alert("số điện thoại chỉ có 10 chữ số");
        } else {
            if (sanphams.length == 0) {
                alert('Giỏ hàng đang trống')
            } else {
                $.post('/Gio_Hang/Dat_hang',
                    {
                        CustomerName: namec,
                        Email: Emailc,
                        Phone: phonec,
                        Address: addressc,
                        Payment: paymentc,
                        Transport: Transportc,
                        Comment: commentc,
                        TotalMoney: totalmonney,
                        products: sanphams
                    }, function (res) {
                        if (res == "err") {
                            alert('bạn chưa đăng nhập!');
                        } else if (res == "error") {
                            alert('có lỗi xảy ra');
                        } else {
                            alert("đặt hàng thành công");
                            sessionStorage.clear();
                            location.reload();
                        }

                    }
                )
            }
        }

    })

});