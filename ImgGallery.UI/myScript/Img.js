
$(document).ready(function () {
    $("[rel='tooltip']").tooltip();

    $('.thumbnail').hover(
        function () {
            $(this).find('.caption').slideDown(250); //.fadeIn(250)
        },
        function () {
            $(this).find('.caption').slideUp(250); //.fadeOut(205)
        }
    );
    //Start Function Upload Photo to Index View.........
    //$("#ShowList").load(function () {
    //    debugger;
        //$.ajax({
        //    url: "/Home/List",
        //    dateType: "GET",
        //    success:function(data) {
        //        $("#ShowList").html(data);
        //    }
        //});
    //});


});

//Function to Show add new Photo .. Show in Poppup Modal....
function CreatePhoto() {
    $(".modal-body").removeAttr('id');
    $(".modal-body").attr('id', 'showCreate');
    $(".btnSave").attr('id', 'btnSavePhotoC');
    var div = $("#showCreate");
    div.load("/Home/Create");
}
//Function to Show Edit Photo .. Show in Poppup Modal....
function EditPhoto(id) {
    $(".modal-body").removeAttr('id').serialize();
    $(".modal-body").attr('id', 'showEdit');
    $(".btnSave").attr('id', 'btnSavePhotoE');
    var div = $("#showEdit");
    div.load("/Home/Edit?photoIdGuid=" + id);
}
