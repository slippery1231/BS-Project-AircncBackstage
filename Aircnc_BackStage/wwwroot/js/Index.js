let app = new Vue({
    el: '#app',
    data: {
        roomCount: '',
        userCount: '',
        lastMonthIncome: '',
        thisMonthIncome: '',
        thisMonthRoom: '',
        thisMonthUser: '',
        todayRoom: '',
        todayUser: '',
        todayIncome:''
    },
    methods: {
        getData() {
            fetch('/api/GetData/GetHomePageData', {
                headers: {
                    'Content-type': 'application/json',
                    'Authorization': GenCurrentAuthBarerFormat(),
                },
                method: 'Get',
            })
                .then(res => res.json())
                .then(jsondata => {
                    this.roomCount = jsondata.roomCount.toLocaleString('en-US'),
                        this.userCount = jsondata.userCount.toLocaleString('en-US'),
                        this.lastMonthIncome = jsondata.lastMonthIncome.toLocaleString('en-US'),
                        this.thisMonthIncome = jsondata.thisMonthIncome.toLocaleString('en-US'),
                        this.thisMonthRoom = jsondata.thisMonthRoom.toLocaleString('en-US'),
                        this.thisMonthUser = jsondata.thisMonthUser.toLocaleString('en-US'),
                        this.todayRoom = jsondata.todayRoom.toLocaleString('en-US'),
                        this.todayUser = jsondata.todayUser.toLocaleString('en-US'),
                        this.todayIncome = jsondata.todayIncome.toLocaleString('en-US')
                })
        }
    },
    created() {
        this.getData()
    }


})

let RoomChartData =
{
    titles: ["排名", "城市", "百分比"],
    data :[]
}
//要給drawChart()的參數
let chartCities = [], chartData = [];
fetch('/api/GetData/GetCharData', {
    headers: {
        'Content-type': 'application/json',
        'Authorization': GenCurrentAuthBarerFormat(),
    },
    method: 'Get',
})
    .then(res => res.json())
    .then(jsondata => {
        jsondata.forEach(x => { RoomChartData.data.push(x) })
        console.log(RoomChartData)
        RoomChartData.data.forEach(item => {//將需要使用的資料迭代後取需要的屬性值加入陣列
            chartCities.push(item.area);
            chartData.push(item.ratio);
        });
        drawChart(chartCities, chartData);
    })





function drawChart(cityarray, dataArray) {
    //Chart長條圖
    let ctxPie2 = document.getElementById("myAreaChart");
    var pieChart = new Chart(ctxPie2, {
        type: 'bar',//bar pie 改變圖表外貿
        data: {
            labels: cityarray,
            datasets: [{
                label: '長條圖',
                data: dataArray,
                backgroundColor: [
                    'rgb(255, 99, 132)',
                    'rgb(255,75,50)',
                    'rgb(255, 205, 86)',
                    'rgb(75, 192, 192)',
                    'rgb(54, 162, 235)',
                    'rgb(153, 102, 255)',
                    'rgb(201, 203, 207)',
                    'rgb(255, 138, 64)',
                    'rgb(142, 65, 64)',
                    'rgb(59, 72, 64)'
                ]
            }, {
                    type: 'line',
                    label: '折線圖',
                data: dataArray,
                fill: true,
                borderColor: 'rgb(75, 192, 192)',
                }

            ],
        },
        options: {
            responsive: true,
            title: {
                display: true,
                fontSize: 26,
                text: '各縣市房源數量比例'
            },
            tooltips: {
                mode: 'point',
                intersect: true,
            },
            legend: {
                position: 'bottom',
                labels: {
                    fontColor: 'black',
                }
            }
        }
    });
}
//2

let OrderChartData =
{
    titles: ["排名", "城市", "百分比"],
    data: []
}
//要給drawChart()的參數
let pieCities = [], pieData = [];
fetch('/api/GetData/GetPieData', {
    headers: {
        'Content-type': 'application/json',
        'Authorization': GenCurrentAuthBarerFormat(),
    },
    method: 'Get',
})
    .then(res => res.json())
    .then(jsondata => {
        jsondata.forEach(x => { OrderChartData.data.push(x) })
        
        OrderChartData.data.forEach(item => {//將需要使用的資料迭代後取需要的屬性值加入陣列
            pieCities.push(item.area);
            pieData.push(item.ratio);
        });
        drawPieChart(pieCities, pieData);
    })
function drawPieChart(cityarray, dataArray) {
    //Pie Chart圓餅圖
    let ctxPie = document.getElementById("myPieChart");
    var pieChart2 = new Chart(ctxPie, {
        type: 'pie',//bar pie 改變圖表外貿
        data: {
            labels: cityarray,
            datasets: [{
                data: dataArray,
                backgroundColor: [
                    'rgb(255, 99, 132)',
                    'rgb(255,75,50)',
                    'rgb(255, 205, 86)',
                    'rgb(75, 192, 192)',
                    'rgb(54, 162, 235)',
                ]
            }],
        },
        options: {
            responsive: true,
            title: {
                display: true,
                fontSize: 26,
                text: '各縣市收益比例'
            },
            tooltips: {
                mode: 'point',
                intersect: true,
            },
            legend: {
                position: 'bottom',
                labels: {
                    fontColor: 'black',
                }
            }
        }
    });
}

