let app = new Vue({
    el: '#app',
    data: {
        roomCount: '',
        userCount: '',
        lastMonthIncome: '',
        thisMonthIncome:''
    },
    methods: {
        getData() {
            fetch('/api/GetData/GetHomePageData', {
                method: 'Get',
            })
                .then(res => res.json())
                .then(jsondata => {
                    this.roomCount = jsondata.roomCount
                    this.userCount = jsondata.userCount
                    this.lastMonthIncome = jsondata.lastMonthIncome.toLocaleString('en-US'),
                    this.thisMonthIncome = jsondata.thisMonthIncome.toLocaleString('en-US')
                })
        }
    },
    created() {
        this.getData()
    }
})