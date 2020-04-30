$(".ResultXoasanpham").click(function (e) {
    e.preventDefault();
    var id = $(this).data('ID');
    $('#item-to-delete').val(id);
});
$('#btnContinueDelete').click(function () {
    var id = $('#item-to-delete').val();
    $.post(@Url.Action("Danhsachsanphamfull", "Home"), { id: id }, function(data) {
        alert("data deleted");
    });
    });