let searchshow = new Vue({
    el: '.searchshow',
    data: {
        results: []
    },
    methods: {
        chooseAddress(item, index) {
            console.log(item.CommodityID)
            selectGames(item.CommodityID)
            return item.CommodityID
        }
    }
})

function selectGames(id) {
    console.log(id)
   /* $.ajax({
        url: "/Home/GetCommodityDetail" + "?CommodityID=" + id,
        type: "post",
        contentType: "application/json",
        async: false,
        dataType: "json",
        data: JSON.stringify({ "ID": id }),
        success: function (data) { //请求成功完成后要执行的方法
            console.log(data)
            //window.location ="/shop/GetCommodityDetail"
        }
    })*/
    window.location = "/Commodity/Details" + "?CommodityID=" + id;
}

function submitSearch() {
    alert($("#Context").val());
    if ($("#searchtype").val() == 1) {
        axios.post("/Search/SearchCommodity?"+"CommodityName=" + $("#Context").val(), $("#Context").val())
            .then(function (response) {
                console.log(response)
                searchshow.results = response.data
               
            })

        /*
        var altstr = $("#Context").val();
        $.ajax({
            url: "/Search/SearchCommodity?+CommodityName=" + altstr,
            type: "post",
            contentType: "application/json",
            async: false,
            dataType: "json",
            data: JSON.stringify({ "ID": altstr }),
            success: function (data) { //请求成功完成后要执行的方法
                console.log(data);
                window.location = "/Commodity/Details" + "?CommodityID=" + altstr;
            }
        })*/
    }
    else {
        axios.post("/Search/SearchPublishers?PublisherName=" + $("#Context").val())
            .then(function (response) {
                console.log(response)
                searchshow.results = response.data
            })
    }
}

function inputChange() {
    var searchnav = document.getElementById("Context");
    console.log("asdasd");
    searchnav.style.border = "none";
}