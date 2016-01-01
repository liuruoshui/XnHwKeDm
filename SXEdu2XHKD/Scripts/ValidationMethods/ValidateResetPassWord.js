$(function () {

    jQuery.validator.addMethod("passwordValidate", function (value, element) {
        var name = /^(?=.*[0-9])(?=.*[a-zA-Z])[a-z0-9A-Z]{6,15}$/;
        return name.test(value);
    }, "密码由字母与数字组成，须包同时含字母，数字，长度为6-15个字符");
   

    var validate = $("#ResetPassWordForm").validate({
        //debug: true, //调试模式取消submit的默认提交功能   
        //errorClass: "label.error", //默认为错误的样式类为：error   
        focusInvalid: false, //当为false时，验证无效时，没有焦点响应  
        onkeyup: false,
        submitHandler: function (form) {   //表单提交句柄,为一回调函数，带一个参数：form
            var md5 = $.md5($("#PassWord").val());
            $("#PassWord").val(md5);
            form.submit();   //提交表单   
        },

        rules: {
            PassWord: {
                required: true,
                passwordValidate: true
            },
            ConfirmPassword: {
                equalTo: "#PassWord"
            }
        },
        messages: {
            PassWord: {
                required: "密码不能为空",
            },
            ConfirmPassword: {
                equalTo: "两次密码输入不一致"
            }
        }
    });
});