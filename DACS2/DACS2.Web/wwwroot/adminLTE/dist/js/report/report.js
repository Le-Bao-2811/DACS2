$(".details").click((ev) => {
    var id = ev.currentTarget.getAttribute("data-id")
    $.get("/admin/report/details/" + id, (res) => {
        $(".modaldetail").html("")
        $(".modaldetail").append(res)
    })
})