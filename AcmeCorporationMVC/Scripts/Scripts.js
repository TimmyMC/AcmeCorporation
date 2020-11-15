$(function () {
    $('#submitForm').on('submit', function (e) {

        $.ajax({
            type: 'post',
            url: 'SubmitSerial',
            data: $('#submitForm').serialize(),
            success: function (response) {
                $("#submissionResult").html(response);
            }
        });
        e.preventDefault();
    });
});