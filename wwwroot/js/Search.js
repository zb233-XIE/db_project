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