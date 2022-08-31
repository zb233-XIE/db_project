let searchshow = new Vue({
    el: '.searchshow',
    data: {
        results: []
    },
    methods: {
        chooseAddress(item, index) {
            console.log(item.ID)
            selectGames(item.ID)
            return item.ID
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

function submitSearch() {
    if ($("#searchtype").val() == 1) {
        axios.post("/Search/SearchCommodity", { Commodity_Name: $("#Context").val() })
            .then(function (response) {
                console.log(response)
                searchshow.results = response.data
            })
    }
    else {
        axios.post("/Search/SearchPublishers", { Publisher: $("#Context").val() })
            .then(function (response) {
                console.log(response)
                searchshow.results = response.data
            })
    }
}

function inputChange() {
    var searchnav = document.getElementById("Context");
    searchnav.style.border = "none";
}