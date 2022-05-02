
let cfg = {
    method: 'get',
    headers: {
        'Content-type': 'application/json',
        'Authorization': GenCurrentAuthBarerFormat(),
    },
    url: '/api/Login/Login',
};

//確認token狀態
axios(cfg)
    .then(res => {
        console.log('123')
        document.getElementById('pagemask').style.display = 'none';
    })
    .catch(err => {
        if (err.response.status === 401) {
            LoginInvalidRedirect();
        }
    })
    .finally(() => {

    });