$(".js-addorupdate").click((ev) => {
    $(".modal-AddorUpdate").html("");

    var id = ev.currentTarget.getAttribute("data-id")
    if (id != null) {
        $("#exampleModalLabel").html("Sửa thể loại tin tức")
        $.get("/admin/CategoryProduct/_Update/" + id, (ev) => {
            $(".modal-AddorUpdate").append(ev);
        })
    } else {
        $("#exampleModalLabel").html("Thêm thể loại sản phẩm")
        $.get("/admin/CategoryProduct/_Create", (ev) => {
            $(".modal-AddorUpdate").append(ev);
        })
    }
})

$(".js-postdata").click(() => {
    var data = $(".id-category").val()
    if (data == "") {
        var files = $(".file")[0].files;
        var formData = new FormData();
        formData.append("file", files[0]);
        var name = $("#categoryName").val()
        
        var model = {
            categoryName: name,
            image: formData
        };
        console.log(model)
        $.ajax({
            url: "/admin/CategoryProduct/_Create",
            type: "POST",
            dataType: 'json',
            data: model,
            processData: false,
            contentType: false,
            success: function (res) {
                if (res == true) {
                    window.location.reload();
                }
            },
        });
    } else {
        var model = $("form").serialize();
        $.post("/admin/CategoryProduct/_Update", model, (res) => {
            if (res == true) {
                window.location.reload();
            }
        })
    }

})