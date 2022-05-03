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

let compaines = [], data = [];//要給drawPieChart()的參數


window.onload = function () {

    marketingShare.data.forEach(item => {//將需要使用的資料迭代後取需要的屬性值加入陣列
        compaines.push(item.Company);
        data.push(item.Ratio);
    });
    drawPieChart(compaines, data);
}
//const marketingShare =
//{
    
//    publish: "2021/12/31",
//    titles: ["排名", "公司名稱", "國別", "市佔率"],
//    data: [
//        { Ranking: 1, Company: "台積電", Country: "台灣", Ratio: "53.1" },
//        { Ranking: 2, Company: "三星電子", Country: "韓國", Ratio: "17.3" },
//        { Ranking: 3, Company: "聯電", Country: "台灣", Ratio: "7.2" },
//        { Ranking: 4, Company: "格羅方德", Country: "美國", Ratio: "6.1" },
//        { Ranking: 5, Company: "中芯國際", Country: "中國", Ratio: "5.3" },
//        { Ranking: 6, Company: "華虹半導體", Country: "中國", Ratio: "2.6" },
//        { Ranking: 7, Company: "力積電", Country: "台灣", Ratio: "1.8" },
//        { Ranking: 8, Company: "世界先進", Country: "台灣", Ratio: "1.4" },
//        { Ranking: 9, Company: "高塔半導體", Country: "以色列", Ratio: "1.4" },
//        { Ranking: 10, Company: "東部高科", Country: "南韓", Ratio: "1" }
//    ]
//};
//        //第一個參數為公司名稱陣列, 第二個參數為資料陣列
//        function drawPieChart(companyArray, dataArray) {
//            //Pie Chart圓餅圖
//            let ctxPie = document.getElementById("myAreaChart");
//        var pieChart = new Chart(ctxPie, {
//            type: 'doughnut',//bar pie 改變圖表外貿
//        data: {
//            labels: companyArray,
//        datasets: [{
//            data: dataArray,
//        backgroundColor: [
//        'rgb(255, 99, 132)',
//        'rgb(255,75,50)',
//        'rgb(255, 205, 86)',
//        'rgb(75, 192, 192)',
//        'rgb(54, 162, 235)',
//        'rgb(153, 102, 255)',
//        'rgb(201, 203, 207)',
//        'rgb(255, 138, 64)',
//        'rgb(142, 65, 64)',
//        'rgb(59, 72, 64)'
//        ]
//                    }],
//                },
//        options: {
//            responsive: true,
//        title: {
//            display: true,
//        fontSize: 26,
//        text: '2021年全球晶圓代工市佔率%'
//                    },
//        tooltips: {
//            mode: 'point',
//        intersect: true,
//                    },
//        legend: {
//            position: 'bottom',
//        labels: {
//            fontColor: 'black',
//                        }
//                    }
//                }
//            });
//        }