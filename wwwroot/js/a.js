
function shanchu(obj) {
    
    $.ajax({
        type: "post",
        url: "/helloworld/shanchu",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ ID: obj.id}), 
        success: function (data) {
                alert(data);
                obj.parentNode.parentNode.parentNode.parentNode.parentNode.innerHTML = " ";
        }
    });
}
function tianjia(obj) {
    var id = document.getElementById("nickname").innerText;
    $.ajax({
        type: "post",
        url: "/helloworld/tianjia",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ ID: id }),
        success: function (data) {
            alert(data);
            window.location.href = "/helloworld/welcome";
        }
    });
    
}
function sousuo(obj)
{
    if ($("#ID").val() == "") {
        alert("搜索不能为空");
        return 0;
    }
    else
        $.ajax({
            type: "post",
            url: "/helloworld/sousuo",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify({ ID: $("#ID").val() }),
            success: function (data) {
                //    window.location = "/helloworld/xianshi"
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
        data: JSON.stringify({ ID: obj.id }),
        success: function (data) {
            alert(data);
            window.location = "/talk/talk" + "?" + obj.id;
        }
    });
}






