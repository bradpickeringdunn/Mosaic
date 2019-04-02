$(":checkbox").click(function () {
    $.post("/home/SetStatus", { id: this.id, status: this.checked }, function (result) {
        window.location.href = "/home/Index/";
    });
});

$(".removeButton").click(function () {
    $.post("/home/RemoveTask", { id: this.id}, function (result) {
        window.location.href = "/home/Index/";
    });
});

$("#addTask").click(function () {
    var name = $("#taskname").val();
    $.post("/home/AddTask", { name: name }, function (result) {
        window.location.href = "/home/Index/";
    });
});