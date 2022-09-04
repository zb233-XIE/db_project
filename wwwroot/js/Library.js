function GetCookie() {
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
}


let searchshow = new Vue({
    el: '.show',
    data: {
        games: []
    },
    methods: {
        chooseAddress(item, index) {
            console.log(item.CommodityID);
            selectGames(item.CommodityID);
            return item.CommodityID
        },
        getLibrary() {
            var that = this
            axios.get("/GameLibrary/HaveGame2")
                .then(function (response) {
                    console.log(response)
                    that.games = response.data
                })
        }
    }
})

function selectGames(id) {
    console.log(id)
    window.location = "/Commodity/Details" + "?CommodityID=" + id+"&Mode=1";
}

/*function submitSearch() {
    axios.post("/Account/SearchCommodity", { Commodity_Name: $("#Context").val() })
        .then(function (response) {
            console.log(response)
            searchshow.games = response.data
        })
}*/

function start() {
    searchshow.getLibrary();

}
window.onload = start();

/*function inputChange() {
    var searchnav = document.getElementById("Context");
    searchnav.style.border = "none";
}*/