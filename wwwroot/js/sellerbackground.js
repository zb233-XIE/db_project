//< !--修改卖家信息并返回--> 只id
function change()
{
    /*
     * cookie方法的实现代码如下：
    var x = GetCookie();
    x = x.replace("UID=", "");
    var cID = $("#ID").val();
    cID = cID.replace("商品ID:", "");
    */
    var uID = "13386092917";
    $.ajax({
        type: "post",
        url: "/SellerBackground/Updatechange" + "?Publisher_ID=" + uID,
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ PublisherID:uID, PublisherName: $("#Name").val(), StartTime: new Date(),Description: $("#Description").val(),HomepageURL: $("#URL").val() }),
        success: function (data) {
            alert("卖家信息已修改成功！" );
        }
    });
}//PublisherID, publisher.PublisherName, publisher.StartTime, publisher.Description, publisher.HomepageURL
//< !--发布游戏补丁并返回--> 只id

function date(obj)
{
    /*
     * cookie方法的实现代码如下：
    var x = GetCookie();
    x = x.replace("UID=", "");
    var cID = $("#ID").val();
    cID = cID.replace("商品ID:", "");
    */
    var uID = "13386092917";
    $.ajax({
        type:"post",
        url: "/SellerBackground/Updatedate",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ CommodityID: $("#ID").val(), VersionNumber: $("#Version_number").val(), UpdateTime: new Date(), Description: $("#Update_content").val() }),
        success: function (data) {
            var jsonData = eval("(" + data + ")");
            alert(jsonData.UpdateDate);
        }
    });
}//(publisherService.PublishGame(commodity.CommodityID, commodity.CommodityName, commodity.PublisherID, commodity.Price, commodity.LowestPrice, commodity.PublishTime, commodity.Description, commodity.PictureURL, commodity.DownLoadURL))
//< !--发布新游戏并返回--> 只id
function publish() {
    /*
     * cookie方法的实现代码如下：
    var x = GetCookie();
    x = x.replace("UID=", "");
    var cID = $("#ID").val();
    cID = cID.replace("商品ID:", "");
    */
    var userID = "13386092917";
    $.ajax({
        type: "post",
        url: "/sellerbackground/Updatepublish" + "?Publisher_ID=" + userID,
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ CommodityID: "ToBeGenerated", CommodityName: $("#Name").val(), PublisherID: userID, Price: $("#Price").val(), LowestPrice: $("#Price").val(), PublishTime: new Date(), Description: $("#Description").val(), PictureURL: $("#PicURL").val(), DownloadURL: $("#DownURL").val()}),
        success: function (data) {
            var jsonData = eval("(" + data + ")");
            alert(jsonData.PublishGame);
        }
    });

}