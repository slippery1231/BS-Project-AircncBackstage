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
                headers: {
                    'Content-type': 'application/json',
                    'Authorization': GenCurrentAuthBarerFormat(),
                },
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

let marketingShare =
{
    titles: ["排名", "城市", "百分比"],
    data :[]
}
//要給drawPieChart()的參數
let cities = [], data = [];
fetch('/api/GetData/GetCharData', {
    headers: {
        'Content-type': 'application/json',
        'Authorization': GenCurrentAuthBarerFormat(),
    },
    method: 'Get',
})
    .then(res => res.json())
    .then(jsondata => {
        jsondata.forEach(x => { marketingShare.data.push(x) })
        console.log(marketingShare)
        marketingShare.data.forEach(item => {//將需要使用的資料迭代後取需要的屬性值加入陣列
            cities.push(item.area);
            data.push(item.ratio);
        });
        drawPieChart(cities, data);
    })




//第一個參數為公司名稱陣列, 第二個參數為資料陣列
function drawPieChart(cityarray, dataArray) {
    //Pie Chart圓餅圖
    let ctxPie = document.getElementById("myAreaChart");
    var pieChart = new Chart(ctxPie, {
        type: 'bar',//bar pie 改變圖表外貿
        data: {
            labels: cityarray,
            datasets: [{
                label:'各縣市',
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
            }],
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
