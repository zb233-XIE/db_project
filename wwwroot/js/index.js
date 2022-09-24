

let show = new Vue({
    el: '.show',
    data: {
        games: [],
        classes: ["休闲", "动作", "多人在线", "模拟", "角色扮演", "冒险"]
    },
    methods: {
        getNew() {
            var that = this
            axios.get("/Home/ShowNewCommodity")
                .then(function (response) {
                    console.log(response)
                    that.games = response.data
                })
        },
        getHot() {
            var that = this
            axios.get("/Home/ShowHotCommodity")
                .then(function (response) {
                    console.log(response)
                    that.games = response.data
                })
        },
        chooseAddress(item, index) {
            console.log(item.ID)
            selectGames(item.ID)
            return item.ID
        },
        chooseClass(item, index) {
            var that=this
            axios.post("/Home/ShowComodityClassification", { "type": item })
                .then(function (response) {
                    console.log(response)
                    that.games = response.data
                })
        }
    }
})

function selectGames(id) {
    console.log(id);
    window.location = "/Commodity/Details" + "?CommodityID=" + id;
    /*$.ajax({
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
}

function getCommoditySlide() {
    axios.get("/Home/ShowShopCommodity")
        .then(function (response) {
            for (var i = 1; i <= 5; i++) {
                document.getElementById("slide" + i.toString()).setAttribute("src", response.data[i-1].PictureURL)
                document.getElementById("slide" + i.toString()).setAttribute("alt", response.data[i-1].ID)
            }
        })
}

$('.slideimg').click(function () {
    var altstr = $(this).attr('alt');
    $.ajax({
        url: "/Home/GetCommodityDetail" + "?CommodityID=" + altstr, 
        type: "post",
        contentType: "application/json",
        async: false,
        dataType: "json",
        data: JSON.stringify({ "ID": altstr }),
        success: function (data) { //请求成功完成后要执行的方法
            console.log(data);
            window.location = "/Commodity/Details" + "?CommodityID=" + altstr;
        }
    })
})

var mySwiper = new Swiper('.swiper', {
    //loop: true, // 循环模式选项
    autoplay:true,

    // 如果需要分页器
    pagination: {
        el: '.swiper-pagination'
    },
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    }
})


function submitSearch() {
   /* if ($("#searchtype").val() == 1) {
        axios.post("/Search/SearchCommodity", { Commodity_Name: $("#Context").val() })
            .then(function (response) {
                console.log(response)
                //searchshow.results = response.data
            })
    }
    else {
        axios.post("/Search/SearchPublishers", { Publisher: $("#Context").val() })
            .then(function (response) {
                console.log(response)
                //searchshow.results = response.data
            })
    }*/
    window.location = "/Search/Search";
}

function start() {
    show.getNew()
    getCommoditySlide()
}
window.onload = start()


function inputChange() {
    var searchnav = document.getElementById("Context");
    searchnav.style.border = "none";
}