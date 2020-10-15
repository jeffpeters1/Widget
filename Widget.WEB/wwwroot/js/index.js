
$('[generate-button]').on('click', function () {
    $("#waiting").show();

    var timeleft = 3;
    var downloadTimer = setInterval(function () {
        timeleft -= 1;
        if (timeleft <= 0) {
            $("#waiting").hide();
            clearInterval(downloadTimer);
        }
    }, 1000);
});