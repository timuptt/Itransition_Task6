$('#openModal').click(function() {
        $('#writeMessageModal').modal('show')
    });

$('#closeModal').click(function() {
    $('#writeMessageModal').modal('hide')
});

$('.utc-date-time').each(function () {
    var utcTime = $(this).html();
    var date = new Date(utcTime);
    $(this).html(date.toLocaleString());
})