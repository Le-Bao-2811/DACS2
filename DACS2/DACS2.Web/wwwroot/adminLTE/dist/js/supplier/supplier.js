$(".js-addorupdate").click((ev) => {
    $(".modal-AddorUpdate").html("");

    var id = ev.currentTarget.getAttribute("data-id")
    if (id != null) {
        $("#exampleModalLabel").html("Sửa nhà cung cấp")
        $.get("/admin/Supplier/_Update/" + id, (ev) => {
            $(".modal-AddorUpdate").append(ev);
        })
    } else {
        $("#exampleModalLabel").html("Thêm nhà cung cấp")
        $.get("/admin/Supplier/_Create", (ev) => {
            $(".modal-AddorUpdate").append(ev);
        })
    }
})

$(".js-postdata").click(() => {
    var data = $(".id-supplier").val()
    if (data == "") {
        var model = $("form").serialize();
        $.post("/admin/Supplier/_Create", model, (res) => {
            if (res == true) {
                window.location.reload();
            }
        })
    } else {
        var model = $("form").serialize();
        $.post("/admin/Supplier/_Update", model, (res) => {
            if (res == true) {
                window.location.reload();
            }
        })
    }

})