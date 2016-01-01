$(function () {

    var validate = $("#LoginForm").validate({
        //debug: true, //调试模式取消submit的默认提交功能   
        //errorClass: "label.error", //默认为错误的样式类为：error   
        focusInvalid: false, //当为false时，验证无效时，没有焦点响应  
        onkeyup: false,
        submitHandler: function (form) {   //表单提交句柄,为一回调函数，带一个参数：form
            var md5 = $.md5($.md5($("#PassWord").val()) + $("#Guid").text());
            $("#PassWord").val(md5);
            form.submit();   //提交表单   
        },

        rules: {
            UserName: {
                required: true
            },
            PassWord: {
                required: true
            }
        },
        messages: {
            UserName: {
                required: "请填写用户名"
            },
            PassWord: {
                required: "密码不能为空"
            }
        }
    });
});