/*
function getCookie(UID) {
    var name = UID + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i].trim();
        if (c.indexOf(name) == 0) 
        var ck=c.substring(name.length, c.length);
        console.log(ck);
        return ck;
    }
    return "";
}*/


function GetCookie()
    {
    var key = "";
    var getCookie = document.cookie.replace(/[ ]/g, "");  //获取cookie，并且将获得的cookie格式化，去掉空格字符
    var arrCookie = getCookie.split(";")  //将获得的cookie以"分号"为标识 将cookie保存到arrCookie的数组中
    var tips;  //声明变量tips
    var UID=arrCookie.toString();
    console.log("ok");
    console.log(UID);
    return UID;
    }


function addToShoppingCart(obj) {
    var x = GetCookie();
    x=x.replace("UID=","");
    var cID=$("#ID").val();
    cID=cID.replace("商品ID:","");
    console.log(x);
    $.post({
        url: "/Commodity/AddToCart" + "?CommodityID=" + cID + "&UserID=" +x,
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ ID: $("#CommodityID").val(), Cookie: x }),
        success: function (data) {
            var jsonData=eval("("+data+")");
            alert(jsonData.REASON);
        }
        
    });
}

function addToWishList(obj) {
    var x = GetCookie();
    x=x.replace("UID=","");
    var cID=$("#ID").val();
    cID=cID.replace("商品ID:","");
    console.log(x);
    $.post({
        url: "/Commodity/AddToWishList"+ "?CommodityID=" + cID + "&UserID=" +x,
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ ID: $("#CommodityID").val(), Cookie: x }),
        success: function (data) {
            var jsonData = eval("(" + data + ")");
            alert(jsonData.REASON);
        }
    });
}

function addEvaluation(obj) {
    var x = GetCookie();
    x = x.replace("UID=", "");
    var y = $("#ID").val();
    y = y.replace("商品ID:", "");
    var z = document.getElementById("content").value;
    console.log(x);
    console.log(y);
    console.log(z);
    $.post({
        url: "/Commodity/AddEvaluation",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ CommodityID: y, BuyerID: x, Description: z, EvaluaionTime: new Date(), AdministratorID:"15566529212" }),
        success: function (data) {
            console.log("asdasdasdsadasdasdasdasdasdasdas");
            var jsonData = eval("(" + data + ")");
            alert(jsonData.REASON);
            location.reload();
            //window.location.href = "/Home/Index";
           window.location.href = "/Commodity/Details?CommodityID="+y;
        }
    });
}