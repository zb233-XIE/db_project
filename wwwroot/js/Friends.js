function GetCookie()
{
    var key = "";
    var getCookie = document.cookie.replace(/[ ]/g, "");  //获取cookie，并且将获得的cookie格式化，去掉空格字符
    var arrCookie = getCookie.split(";")  //将获得的cookie以"分号"为标识 将cookie保存到arrCookie的数组中
    var tips;  //声明变量tips
    var UID = arrCookie.toString();
    console.log("ok");
    console.log(UID);
    return UID;
}


function shanchu(obj) {
    var uID = GetCookie();
    uID = uID.replace("UID=", "");
    /*var uID = "13812345678"; //如果cookie出现问题先拿这个调！*/
    $.ajax({
        type: "post",
        url: "/Friends/shanchu" + "?UserID=" + uID,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify( obj.id) ,
        success: function (data) {
            alert(data);
            obj.parentNode.parentNode.parentNode.parentNode.parentNode.innerHTML = " ";
        }
    });
}

function tianjia(obj)
{
    var id = document.getElementById("signature").innerText;
    //现在SIGNATURE == ID
    var uID = GetCookie();
    uID = uID.replace("UID=", "");
    /*var uID = "13812345678"; //如果cookie出现问题先拿这个调！*/
    $.ajax({
        type: "post",
        url: "/Friends/tianjia" + "?UserID=" + uID,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(id),
        success: function (data) {
            alert(data);
            window.location.href = "/Friends/welcome" + "?UserID=" + uID;
        }
    });

}
function sousuo(obj)
{
    var ID = $("#ID").val();
    console.log(ID);//MESSAGE;
    var uID = GetCookie();
    uID = uID.replace("UID=", "");
    /*var uID = "13812345678"; //如果cookie出现问题先拿这个调！*/
    if ($("#ID").val() == "") {
        alert("搜索不能为空");
        return 0;
    }
    else
        $.ajax({
            type: "post",
            url: "/Friends/sousuo" + "?UserID=" + uID,
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify($("#ID").val()),
            success: function (data) {
                alert(data.nickName);
                var b = document.getElementById("nickname");
                b.innerHTML = data.nickName;
                b = document.getElementById("signature");
                b.innerHTML = data.signature;
                b = document.getElementById("picture")
                b.src = data.face;
                var a = document.getElementById("div1");
                a.style.visibility = 'visible';
            }
        });

}

function liaotian(obj) {

    $.ajax({
        type: "post",
        url: "/talk/liaotian",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ ID: obj.id}),
        success: function (data) {
            

            var a =obj.id;
            
            window.location = "/talk/talk" + "?UID=" + a;
        }
    });
}