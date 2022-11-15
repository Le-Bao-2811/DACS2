window.addEventListener("load", () => {
    $(".js-fillterprice").click(ev => {
        var value = ev.currentTarget.getAttribute("value")
        $.post("/home/_FillterProduct", { fillter: value }, (res) => {
            
        })
    })
})