function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i].trim();
        if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
    }
    return "";
}

let searchshow = new Vue({
    el: '.show',
    data: {
        games: []
    },
    methods: {
        chooseAddress(item, index) {
            console.log(item.ID)
            selectGames(item.ID)
            return item.ID
        },
        getLibrary() {
            var that = this
            axios.get("/Account/getLibrary")
                .then(function (response) {
                    console.log(response)
                    that.games = response.data
                })
        }
    }
})

function selectGames(id) {
    console.log(id)
    $.ajax({
        url: "/Home/GetCommodityDetail",
        type: "post",
        contentType: "application/json",
        async: false,
        dataType: "json",
        data: JSON.stringify({ "ID": id }),
        success: function (data) { //请求成功完成后要执行的方法
            console.log(data)
            //window.location ="/shop/GetCommodityDetail"
        }
    })
}

function start() {
    show.getLibrary();

}
window.onload = start();