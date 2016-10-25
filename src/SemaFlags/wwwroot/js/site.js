// Write your Javascript code.
$(".userBox").change(updateUser);

function updateUser() {
    var nodeId = $(this).attr('id').replace(/\D/g, '');
    var userId = $(this).val()
    var xhttp = new XMLHttpRequest();
    var stateId = "#state" + nodeId;
    $(stateId).html("<img src='/images/ajax-loader.gif'/>");

    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            $(stateId).html("<span class='glyphicon glyphicon-ok' style='color:green'></span>");
        }
    };

    xhttp.open("POST", "/Node/ChangeUser", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send("userId=" + userId + "&nodeId=" + nodeId);

    return 3;
}