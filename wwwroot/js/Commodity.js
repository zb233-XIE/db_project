﻿


function addToShoppingCart(obj)
{
    $.post({
        url: "/Commodity/AddToCart",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ ID: $("#ID").val() }),
        success: function (data) {
            alert("已将编号为"+data.ID+"的游戏加入购物车");
        }
    });
}

function addToWishList(obj) {
    $.post({
        url: "/Commodity/AddToWishList",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ ID: $("#ID").val() }),
        success: function (data) {
            alert("已将编号为" + data.ID + "的游戏加入愿望单");
        }
    });
}

function addEvaluation() {
 //   var x = GetCookie();
   // x = x.replace("UID=", "");
    /* var x = 300;
    $.post({
        url: "Commodity/AddEvaluation",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ CommodityID: $("#ID").val(), BuyerID: x, Description: $("#content".val()) }),
        success: function (data) {
            console.log(data);
        }
    })*/
    alert("lll");
}