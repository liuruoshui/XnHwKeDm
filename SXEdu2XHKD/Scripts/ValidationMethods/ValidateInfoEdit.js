jQuery.validator.addMethod("nameValidate", function (value, element) {
    var name = /^([\u4e00-\u9fa5]+|([a-zA-Z]+\s?)+)$/;
    return name.test(value);
}, "请输入正确的姓名");

jQuery.validator.addMethod("EmailValidate", function (value, element) {
    var email = /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
    return this.optional(element) || email.test(value);
}, "请输入正确的邮箱");

jQuery.validator.addMethod("QQValidate", function (value, element) {
    var QQ = /^\d{5,10}$/;
    return this.optional(element) || QQ.test(value);
}, "请输入正确的QQ号");

var validate = $("#MemberInfoEditForm").validate({
    //debug: true, //调试模式取消submit的默认提交功能   
    //errorClass: "label.error", //默认为错误的样式类为：error   
    focusInvalid: false, //当为false时，验证无效时，没有焦点响应  
    onkeyup: false,
    submitHandler: function (form) {   //表单提交句柄,为一回调函数，带一个参数：form
        form.submit();   //提交表单   
    },

    rules: {
        ClassName:{
            required: true

        },
        Name: {
            required: true,
            nameValidate: true
        },
        Email: {
            EmailValidate: true
        },
        QQ: {
            QQValidate: true
        }
    },
    messages: {
        Name: {
            required: "姓名不能为空"
        },
        ClassName: {
            required: "班级不能为空"
        }
    }
});