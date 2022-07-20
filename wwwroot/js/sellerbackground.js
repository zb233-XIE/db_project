//< !--修改卖家信息并返回--> 只id
function change() {
    var ID = $("#ID").val();
    console.log(ID);
    $.ajax({
        url: "/sellerbackground/Updatechange",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: { ID: ID },
        success: function (data) {
            alert("卖家信息已修改ID为：" + data );
        }
    });

}

//< !--发布游戏补丁并返回--> 只id
function date() {
    var ID = $("#ID").val();
    console.log(ID);
    $.ajax({
        url: "/sellerbackground/Updatedate",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: { ID: ID },
        success: function (data) {
            alert("游戏补丁已发布ID为：" + data);
        }
    });

}

//< !--发布新游戏并返回--> 只id
function publish() {
    var ID = $("#ID").val();
    console.log(ID);
    $.ajax({
        url: "/sellerbackground/Updatepublish",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: { ID: ID },
        success: function (data) {
            alert("新游戏已发布ID为：" + data);
        }
    });

}