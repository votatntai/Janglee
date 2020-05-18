/*Ajax Login*/
$(function () {
    let form = $("#form-login");
    form.on('submit', function (e) {
        e.preventDefault();
        let url = form.attr("action");
        let data = form.serialize();
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            success: function (res) {
                if (res === "success") {
                    location.href = "Users/Index";
                }
                else {
                    $('#message').html('Your username or password is invalid');
                    $('#modal').modal('show');
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $('#message').html(errorThrown);
                $('#modal').modal('show');
            }
        });
    });
});

/*Ajax Register*/
$(function () {
    let form = $("#form-register");
    form.on('submit', function (e) {
        e.preventDefault();
        let url = form.attr("action");
        let data = form.serialize();
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            success: function (res) {
                if (res === "success") {
                    location.reload();
                }
                else if (res === "duplicate") {
                    $('#message').html('Username exited');
                    $('#modal').modal('show');
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $('#message').html(errorThrown);
                $('#modal').modal('show');
            }
        });
    });
});
/* Show model ERROR-PAGE */
$("#error-modal").modal('show');
