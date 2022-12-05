$(document).ready(() => {
    $(document).on("click", ".menuclient", (ev) => {
        var id = ev.target.getAttribute("data-id");
        window.location.href = "/home/Menu/"+id;
    })
})