$(":checkbox").click(function () {
    $.post("/home/SetStatus", { id: this.attr('id'), status: this.checked }, function (result) {
        alert(result);
    });
});

$(".removeButton").click(function () {
    $.post("/home/SetStatus", { id: this.attr('id')}, function (result) {
        alert(result);
    });
});

$("#addTask").click(function () {
    $.post("/home/SetStatus", { id: this.attr('id') }, function (result) {
        alert(result);
    });
});