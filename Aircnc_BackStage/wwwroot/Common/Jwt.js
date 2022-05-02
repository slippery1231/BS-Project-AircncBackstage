function LoginInvalidRedirect() {
    window.location.href = '/Home/Login';
}

function LoginValidRedirect() {
    window.location.href = '/Home/Index';
}

function TokenSetter(value) {
    return Cookies.set('accessToken', value);
}

function TokenGetter() {
    return Cookies.get('accessToken');
}

//產生Authorize Bear 格式
function GenCurrentAuthBarerFormat() {
    return `Bearer ${TokenGetter()}`;
}

window.onload = function () {
    //判斷是否有TOKEN
    if (Cookies.get('accessToken') == null) {
        window.location.href = '/Home/Login'
    }
    else {
        console.log(GenCurrentAuthBarerFormat())
        //判斷token是否有效
        fetch('https://localhost:5001/api/APILogin/Test', {
            method: 'get',
            headers: {
                'Content-type': 'application/json',
                'Authorization': GenCurrentAuthBarerFormat(),
            },

        }).then(res => {

            if (res.status == 200) {

               
            }
            else {
                window.location.href = '/Home/Login';
            }
        })

    }
}