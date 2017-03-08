
$(document).ready(function () {

    showing();

});
function showing() {
         //Start Function Upload Photo to Index View.........
    $(".ShowList").load("/Home/List", function () {
        //Call Function to display photos in Index View.......
        displayList();
    });
    }
   
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
    $(".modal-body").removeAttr('id');
    $(".modal-body").attr('id', 'showEdit');
    $(".btnSave").attr('id', 'btnSavePhotoE');
    var div = $("#showEdit");
    div.load("/Home/Edit?photoIdGuid=" + id);
}

//Function to Show Delete Photo .. Show in Poppup Modal....
function DeletePhoto(id) {
    $(".modal-body").removeAttr('id');
    $(".modal-body").attr('id', 'showDelete');
    $(".btnSave").attr('id', 'btnDelete');
    var div = $("#showDelete");
    div.load("/Home/Delete?id=" + id);
}



function displayList() {
    //setTimeout(function () {
        //debugger;
    $("[rel='tooltip']").tooltip();

    $('.thumbnail').hover(
        function () {
            $(this).find('.caption').slideDown(250); //.fadeIn(250)
        },
        function () {
            $(this).find('.caption').slideUp(250); //.fadeOut(205)
        }
    );
   //},1500);
} 