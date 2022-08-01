//< !--修改卖家信息并返回--> 只id
function edit() {
    var ID = $("#ID").val();
    console.log(ID);
    $.ajax({
        url: "/adminaction/Updateedit",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: { ID: ID },
        success: function (data) {
            alert("卖家信息已修改ID为：" + data );
        }
    });

}


function tempdelete() {
    var ID = $("#ID").val();
    console.log(ID);
    $.ajax({
        url: "/adminaction/Updatetempdelete",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: { ID: ID },
        success: function (data) {
            alert("商品信息已删除");
        }
    });

}
function search() {
    var ID = $("#ID").val();
    console.log(ID);
    $.ajax({
        url: "/adminaction/SEARCH",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: { id: ID },
        success: function (data) {
            console.log(data);
            var d = data[0];
            $("#uid").val(d["ID"]);
            $("#Name").val(d["Name"]);
            $("#Publisher").val(d["Publisher"]);
            $("#Price").val(d["Price"]);
            $("#Time").val(d["Time"]);
            $("#Classification").val(d["Classification"]);
            $("#Downloadurl").val(d["Downloadurl"]);
            $("#Volume").val(d["Volume"]);
            $("#Description").val(d["Description"]);
            alert("商品信息已搜索成功");
        }
    });

}

function DELETE() {
    var ID = $("#ID").val();
    console.log(ID);
    $.ajax({
        url: "/adminaction/Updatedelete",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: { id: ID },
        success: function (data) {
            console.log(data);
        }
    });

}


//< !--发布新游戏并返回--> 只id
function create() {
    var ID = $("#ID").val();
    console.log(ID);
    $.ajax({
        url: "/adminAction/Updatecreate",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: { ID: ID },
        success: function (data) {
            alert("新游戏已发布ID为：" + data);
        }
    });

}