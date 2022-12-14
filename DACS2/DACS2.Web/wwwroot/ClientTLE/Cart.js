function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

window.addEventListener("load", () => {
    getcart();
    countproduct();
   
    
    $(".voucher").click((ev) => {
        ev.preventDefault();
        var voucher = $(".text-voucher").val();        
        $.post("/cart/addVoucher", { voucher }, (res) => {
            if (res == false) {
                new AWN().alert('Không tìm thấy mã giảm giá', { durations: { success: 0 }, labels: { alert: "Thất bại" } })
                return;
            }
            $(".useVoucher").val(voucher)
            if (res.percent !== null) {
                var totalprice = $(".total-price").text();
                var text = splittotal(totalprice);
                var pay = Number(text) - ((Number(text) * res.percent) / 100);
                var pricevoucher = res.percent + "%";
                $(".price-voucher").text(pricevoucher)
                $(".pay").text(pay.toLocaleString("de-DE"))
            } else if (res.price != null) {
                var totalprice = $(".total-price").text();
                var text = splittotal(totalprice);
                var pay = Number(text) - Number(res.price);
                var pricevoucher = res.price.toLocaleString("de-DE")
                $(".price-voucher").text(pricevoucher)
                $(".pay").text(pay.toLocaleString("de-DE"))
            }
            allprice()
            new AWN().success('Thêm mã giảm giá thành công', { durations: { success: 0 }, labels: { success: " thành công" } })
        })
    })
})
function splittotal(text) {
    var total = "";
    text = text.split(".")
    for (let i = 0; i < text.length; i++) {
        total = total + text[i];
    }
    return total
}
function countproduct() {
    const allCookie = document.cookie;
    const cookieArray = allCookie.split(';');

    var newArrayCookie = [];
    for (var i = 0; i < cookieArray.length; i++) {
        if (cookieArray[i].indexOf("products_") != -1) {
            newArrayCookie.push(parseInt(cookieArray[i].replace("products_", "").split("=")[0].trim()));
        }
    };
    var count = 0;
    for (let i = 0; i < newArrayCookie.length; i++) {
        count++;
    }
    $(".js-count").text(count);
}
const split = () => {
    var cookieString = document.cookie.split(';');

    var intArr = [];

    for (var i = 0; i < cookieString.length; i++) {

        if (cookieString[i].indexOf("products_") > -1) {
            var temp = cookieString[i].replace("products_", "")
            var interger = temp.split("=")[0];
            intArr.push(interger);
        }
    }
}


// thêm sản phẩm vào giỏ hàng
$(document).on("click", ".add-cart", function (ev) {
    var current = ev.currentTarget;
    var amount = $(".amount").val();   

    // lấy size,màu,kiểu dáng
    var size = "";
    var color = "";
    var selected = $("input[type='radio'][name='size']:checked");
    var idadd = current.getAttribute('data-id');
    idadd = parseInt(idadd);
    $.get("/cart/getOneProduct/" + idadd, (data) => {
        if (data.amount < amount) {
            new AWN().alert('Số lượng còn lại trong kho không đủ', { durations: { success: 0 }, labels: { alert: "Thao tác thất bại" } })
            return
        }
        if (selected.length > 0) {
            size = selected.attr("data-id");
        }
        var selected1 = $("input[type='radio'][name='color']:checked");
        if (selected1.length > 0) {
            color = selected1.attr("data-id");
        }
        if (size == "", color == "") {
            new AWN().alert('Vui lòng chọn size và màu sắc', { durations: { success: 0 }, labels: { alert: "Thao tác thất bại" } })

        } else {


            var strings = amount + "-" + size + "-" + color;
            setCookie('products_' + idadd, strings, 200);
            new AWN().success('đã thêm sản phẩm vào giỏ hàng', { durations: { success: 0 }, labels: { success: "Thêm thành công" } })
        }
    })
  
    

})
const getcart = () => {
    const allCookie = document.cookie;
    const cookieArray = allCookie.split(';');

    var newArrayCookie = [];
    for (var i = 0; i < cookieArray.length; i++) {
        if (cookieArray[i].indexOf("products_") != -1) {
            newArrayCookie.push(parseInt(cookieArray[i].replace("products_", "").split("=")[0].trim()));
        }
    };
    const tbody = document.querySelector("#cart");
    tbody.innerHTML = "";
    if (newArrayCookie.length == 0) {

    }
    else {
        $.post("/cart/getProduct", { listid: newArrayCookie }, (data) => {
            if (data.length > 0) {
                const tbody = document.querySelector("#cart");
                tbody.innerHTML = "";
                for (var i = 0; i < data.length; i++) {
                    if (data[i] != ",") {
                        console.log(data[i])
                        const { productName, price, pathImgP, id, size, color } = data[i];
                        var cookies = getCookie("products_" + id)
                        var stringaray = cookies.split("-");
                        var html = `  <tr>
                        <td class="align-middle"><img src="/img/products/${pathImgP}" alt="" style="width: 50px;"><div  style="width: 90px;height: 30px;text-overflow:ellipsis;overflow:hidden"> ${productName} </div></td>
                        <td class="align-middle">${price.toLocaleString("de-DE")}</td>
                        <td class="align-middle price" hidden>${price}</td>
						<td class="align-middle"> ${color}</td> 
						<td class="align-middle"> ${size} </td> 
                        <td class="align-middle">
                            <div class="input-group quantity mx-auto" style="width: 100px;">
                                <div class="input-group-btn">
                                    <a data-id="${id}" class="btn btn-sm btn-primary btn-minus giam">
                                        -
                                    </a>
                                </div>
                                <input type="text" class="form-control form-control-sm bg-secondary border-0 text-center amount" value="${stringaray[0]}">
                                <div class="input-group-btn">
                                    <a data-id="${id}" class="btn btn-sm btn-primary btn-plus tang">
                                        +
                                    </a>
                                </div>
                            </div>
                        </td>
                        <td class="align-middle total"></td>
                        <td class="align-middle"><a data-id="${id}" class="btn btn-sm btn-danger removecookies">X</i></a></td>
                    </tr>`;
                        tbody.insertAdjacentHTML('beforeend', html);
                    }
                }
                totalprice()
                allprice()
            }
        }).then(function () {
            $('.tang').on('click', function (ev) {
                ev.preventDefault();

                var btn = ev.target;
                var div = btn.parentElement;
                var td = div.parentElement;
                var input = td.querySelector("input");

                var value = input.value;
                var value1 = Number(value) + 1;

                input.value = value1;



                var id = ev.currentTarget.getAttribute("data-id")
                var cookies = getCookie("products_" + id)
                var stringaray = cookies.split("-");
                stringaray[0] = value1;
                var string = stringaray[0] + "-" + stringaray[1] + "-" + stringaray[2] 
                setCookie("products_" + id, string, 200)
                totalprice()
                allprice()
            })
            $('.giam').on('click', function (ev) {
                ev.preventDefault();
                var btn = ev.target;
                var div = btn.parentElement;
                var td = div.parentElement;
                var input = td.querySelector("input");
                var value = input.value;
                if (value === "1") {
                    return;
                }
                var value1 = Number(value) - 1;

                input.value = value1;

                var id = ev.currentTarget.getAttribute("data-id")
                var cookies = getCookie("products_" + id)
                var stringaray = cookies.split("-");
                stringaray[0] = value1;
                var string = stringaray[0] + "-" + stringaray[1] + "-" + stringaray[2] 
                setCookie("products_" + id, string, 200)
                totalprice()
                allprice()
            })
            $(".removecookies").on("click",(ev) => {
                ev.preventDefault();
                var id = ev.target.getAttribute("data-id")
                console.log("đã vô đât", id);
                setCookie("products_" + id, "", -1);
                getcart();
                allprice()
            })
        })
    }
}
function totalprice() {
    var price = document.querySelectorAll("tbody tr")
    var allprice = 0;
    if (price.length != 0) {
        for (var i = 0; i < price.length; i++) {
            var tong = 0;
            var gia = price[i].querySelector(".price").innerHTML;
            var soluong = price[i].querySelector("input").value;
            tong = (gia * soluong)
            allprice += tong;
            var total = price[i].querySelector(".total");
            total.innerHTML = tong.toLocaleString("de-DE");
        }
    }
    $(".total-price").text(allprice.toLocaleString("de-DE"))
    $(".pay").text(allprice.toLocaleString("de-DE"))
}
function allprice() {
    var postprice = $(".totalMoney");
    var price = $(".pay").text();
    var temp = splittotal(price)
    postprice.val(temp)
}




