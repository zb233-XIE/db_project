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
//< !--删除买家信息并返回--> 只id
function tempdeletebuyer() {
    var ID = $("#ID").val();
    console.log(ID);
    $.ajax({
        type: "post",
        url: "/AdminAction/DeleteBuyer" + "?deleteBuyerID=" + $("#ID").val(),
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ buyerID: $("#ID").val() }),
        success: function (data) {
            alert("买家信息已删除");
        }
    });

}
//< !--删除商品信息并返回--> 只id
function tempdelete() {
    var ID = $("#ID").val();
    console.log(ID);
    $.ajax({
        type: "post",
        url: "/AdminAction/DeleteCommodity" + "?CommodityID=" + $("#ID").val(),
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ commodityID: $("#ID").val() }),
        success: function (data) {
            alert("商品信息已删除");
        }
    });

}
/*function search() {
    $.ajax({
        type: "post",
        url: "/Commodity/CommodityDetails" + "?CommodityID=" + $("#ID").val(),
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: { commodityID: $("#ID").val() },
        success: function (data) {
            console.log(data);
           
            
            var result = JSON.stringify(JSON.parse(data), null, 2);//将字符串转换成json对象

           // var a = JSON.parse(data);
           // console.log(a);
           // var d = data[0];jsonData.CommodityID
            var b = document.getElementById("uid");
            b.innerHTML = result;
            var b = document.getElementById("Name");
            b.innerHTML = jsonData.CommodityName;
            //alert(jsonData.ID + "商品信息已搜索成功" + jsonData.Name);
        }
    });

}
*/

function search() {
    $.ajax({
        type: "post",
        url: "/Commodity/CommodityDetails" + "?CommodityID=" + $("#ID").val(),
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ commodityID: $("#ID").val() }),
        success: function (data) {
            console.log(data);
            var jsonData = eval("(" + data + ")");
          //  var d = jsonData[0];
          
          //  var i in jsonData;
            var b = document.getElementById("uid");
            b.value = jsonData["CommodityID"];
            var b = document.getElementById("Name");
            b.value = jsonData["CommodityName"];
            var b = document.getElementById("Publisher");
            b.value = jsonData["PublisherID"];
            var b = document.getElementById("Price");
            b.value = jsonData["Price"];
            var b = document.getElementById("Time");
            b.value = jsonData["PublishTime"];
            var b = document.getElementById("LowestPrice");
            b.value = jsonData["LowestPrice"];
            var b = document.getElementById("Downloadurl");
            b.value = jsonData["DownLoadURL"];
            var b = document.getElementById("Volume");
            b.value = jsonData["SalesVolume"];
            var b = document.getElementById("Description");
            b.value = jsonData["Description"];
            var b = document.getElementById("PictureURL");
            b.value = jsonData["PictureURL"];
          /*  for (var i in jsonData) {//循环json对象数组
                //循环json对象中的属性和值
                alert("field:" + i + ", value:" + jsonData[i]);
                var b = document.getElementById("uid");
                b.innerHTML = jsonData[i];
            }*/
            alert("商品信息已搜索成功");
        }

    });

}

//搜索买家id
function searchbuyer() {
    $.ajax({
        type: "post",
        url: "/AdminAction/BuyerDetails" + "?BuyerID=" + $("#ID").val(),
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ buyerID: $("#ID").val() }),
        success: function (data) {
            console.log(data);
            var jsonData = eval("(" + data + ")");
            //  var d = jsonData[0];

            //  var i in jsonData;
            var b = document.getElementById("uid");
            b.value = jsonData["BuyerID"];
            var b = document.getElementById("Name");
            b.value = jsonData["BuyerName"];
            var b = document.getElementById("Mail");
            b.value = jsonData["Mail"];
            /*  for (var i in jsonData) {//循环json对象数组
                  //循环json对象中的属性和值
                  alert("field:" + i + ", value:" + jsonData[i]);
                  var b = document.getElementById("uid");
                  b.innerHTML = jsonData[i];
              }*/
            alert("买家信息已搜索成功");
        }

    });

}

function DELETE() {
    var ID = $("#ID").val();
    console.log(ID);
    $.ajax({
        type: "post",
        url: "/AdminAction/DeleteCommodity",
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
        data: JSON.stringify({ commodityID: $("#ID").val() }),
        success: function (data) {
            alert("新游戏已发布ID为：" + data);
        }
    });

}