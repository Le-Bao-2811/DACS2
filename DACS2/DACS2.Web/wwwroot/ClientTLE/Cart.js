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
})
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
	var size = "";
	var color = "";
	var selected = $("input[type='radio'][name='size']:checked");
	if (selected.length > 0) {
		size = selected.val();
	}
	var selected1 = $("input[type='radio'][name='color']:checked");
	if (selected1.length > 0) {
		color = selected1.val();
	}
	var idadd = current.getAttribute('data-id');
	var strings = "amount:1,size:" + size + ",color:" + color;
	setCookie('products_' + idadd, strings, 200);
	//split();	
})
const getcart = () => {
	const allCookie = document.cookie;
	const cookieArray = allCookie.split(';');
	console.log(cookieArray);
	var newArrayCookie = [];
	for (var i = 0; i < cookieArray.length; i++) {
		if (cookieArray[i].indexOf("products_") != -1) {
			newArrayCookie.push(parseInt(cookieArray[i].replace("products_", "").split("=")[0].trim()));
		}
	};
	if (newArrayCookie.length == 0) {

	}
	else {
		$.post("/cart/getProduct", { listid: newArrayCookie }, (data) => {
			if (data.length > 0) {
				const tbody = document.querySelector("#cart");
				tbody.innerHTML = "";
				for (var i = 0; i < data.length; i++) {
					const { productName, price, pathImgP, id } = data[i];
					var html = `  <tr>
                        <td class="align-middle"><img src="/img/products/${pathImgP}" alt="" style="width: 50px;"> ${productName}</td>
                        <td class="align-middle">$150</td>
                        <td class="align-middle">
                            <div class="input-group quantity mx-auto" style="width: 100px;">
                                <div class="input-group-btn">
                                    <button class="btn btn-sm btn-primary btn-minus">
                                        <i class="fa fa-minus"></i>
                                    </button>
                                </div>
                                <input type="text" class="form-control form-control-sm bg-secondary border-0 text-center" value="1">
                                <div class="input-group-btn">
                                    <button class="btn btn-sm btn-primary btn-plus">
                                        <i class="fa fa-plus"></i>
                                    </button>
                                </div>
                            </div>
                        </td>
                        <td class="align-middle">${price}</td>
                        <td class="align-middle"><button class="btn btn-sm btn-danger"><i class="fa fa-times"></i></button></td>
                    </tr>`;
					tbody.insertAdjacentHTML('beforeend', html);
				}
			}
		})
	}
}

