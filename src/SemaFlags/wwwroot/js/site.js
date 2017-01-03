// Write your Javascript code.
$(".userBox").change(updateUserAjax);

//function updateUser() {
//    var nodeId = $(this).attr('id').replace(/\D/g, '');
//    var userId = $(this).val()
//    var xhttp = new XMLHttpRequest();
//    var stateId = "#state" + nodeId;
//    $(stateId).html("<img src='/images/ajax-loader.gif'/>");

//    xhttp.onreadystatechange = function () {
//        if (this.readyState == 4 && this.status == 200) {
//            $(stateId).html("<span class='glyphicon glyphicon-ok' style='color:green'></span>");
//        }
//    };

//    xhttp.open("POST", "/Node/ChangeUser", true);
//    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
//    xhttp.send("userId=" + userId + "&nodeId=" + nodeId);
//}

function claimNode( nodeId,  userId) {
    //var nodeId = $(this).attr('id').replace(/\D/g, '');
    //var userId = $(this).val()

    var stateId = "#state" + nodeId;
    var nodeAction = "#nodeAction" + nodeId;
    $(stateId).html("<img src='/images/ajax-loader.gif'/>");

    $.ajax({
        url: "/Node/ChangeUser",
        type: 'POST',
        data: { userId: userId, nodeId: nodeId },
        error: function (data) {
            $(stateId).html("<span class='glyphicon glyphicon-remove' style='color:red'></span>" +
                            "Unknown");
            
        },
        success: function (data) {
            $(stateId).html("<span class='glyphicon glyphicon-ok' style='color:green'></span>");
            $(nodeAction).html("<button onclick='releaseNode(" + nodeId + ", " + userId + ")'>Release</button>");
        }

    });
}

function releaseNode(nodeId, userId) {
    //var nodeId = $(this).attr('id').replace(/\D/g, '');
    //var userId = $(this).val()

    var stateId = "#state" + nodeId;
    var nodeAction = "#nodeAction" + nodeId;
    $(stateId).html("<img src='/images/ajax-loader.gif'/>");

    $.ajax({
        url: "/Node/ChangeUser",
        type: 'POST',
        data: { userId: 0, nodeId: nodeId },
        error: function (data) {
            $(stateId).html("<span class='glyphicon glyphicon-remove' style='color:red'></span>");
            $(nodeAction).html("Unknown");

        },
        success: function (data) {
            $(stateId).html("<span class='glyphicon glyphicon-ok' style='color:green'></span>");
            $(nodeAction).html("<button onclick='claimNode(" + nodeId + ", " + userId + ")'>Claim</button>");
        }

    });
}



function updateUserAjax() {
    var nodeId = $(this).attr('id').replace(/\D/g, '');
    var userId = $(this).val()
    
    var stateId = "#state" + nodeId;
    $(stateId).html("<img src='/images/ajax-loader.gif'/>");

    $.ajax({
        url: "/Node/ChangeUser",     
        type: 'POST', 
        data: { userId: userId, nodeId: nodeId },
        error: function (data) {
            $(stateId).html("<span class='glyphicon glyphicon-remove' style='color:red'></span>");
        },
        success: function(data){ 
            $(stateId).html("<span class='glyphicon glyphicon-ok' style='color:green'></span>");
        }
       
      });
}