
let show = new Vue({
    el: '.show',
    data: {
        games:[]
    },
    methods: {
        getNew() {
            var that = this
            axios.get("/shop/ShowNewCommodity")
                .then(function (response) {
                    console.log(response)
                    that.games = response.data
                })
        },
        getHot() {
            var that = this
            axios.get("/shop/ShowHotCommodity")
                .then(function (response) {
                    console.log(response)
                    that.games = response.data
                })
        },
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
        url: "/shop/GetCommodityDetail",
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

function getCommoditySlide() {
    axios.get("/shop/ShowShopCommodity")
        .then(function (response) {
            console.log(response.data[0].img)
            for (var i = 1; i <= 5; i++) {
                document.getElementById("slide" + i.toString()).setAttribute("src", response.data[i-1].img)
            }
        })
}

function getActivitySlide() {
    axios.get("/shop/ShowCurrentActivity")
        .then(function (response) {
            console.log(response.data[0].img)
            for (var i = 6; i <= 8; i++) {
                document.getElementById("slide" + i.toString()).setAttribute("src", response.data[i - 6].img)
            }
        })
}

var mySwiper = new Swiper('.swiper', {
    loop: true, // 循环模式选项
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

let classification = new Vue({
    el: '.classification',
    data: {
        classes:["休闲","动作","多人在线","模拟","角色扮演","冒险"]
    },
    methods: {
        chooseClass(item,index) {
            axios.post("/shop/ShowComodityClassification", { "classification": item })
                .then(function (response) {
                    console.log(response)
                    show.games = response.data
                })
        }
    }
})

function start() {
    show.getNew()
    getCommoditySlide()
    getActivitySlide()
}
window.onload = start()