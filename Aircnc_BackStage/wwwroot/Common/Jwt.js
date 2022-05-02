function LoginInvalidRedirect() {
    window.location.href = '/Home/Login';
}

function LoginValidRedirect() {
    window.location.href = '/Home/Index';
}

function TokenSetter(value) {
    return Cookies.set('accessToken', value, { expires: 2});
}

function TokenGetter() {
    return Cookies.get('accessToken');
}

//產生Authorize Bear 格式
function GenCurrentAuthBarerFormat() {
    return `Bearer ${TokenGetter()}`;
}
//載入頁面時判斷是否有登入
window.onload = function () {
    //判斷是否有TOKEN
    if (Cookies.get('accessToken') == null) {
        window.location.href = '/Home/Login'
    }
    else {
        console.log(GenCurrentAuthBarerFormat())
        //判斷token是否有效
        fetch('/api/APILogin/CheckToken', {
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
//登出
function Logout()
{
    Cookies.remove('accessToken');
    window.location.href = '/Home/Login';
}