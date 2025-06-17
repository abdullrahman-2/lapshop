(function ($) {
    'use strict';
    var form = $("#example-form");
    form.children("div").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        onFinished: function (event, currentIndex) {
            alert("Submitted!");
        },
        onLastStep: function (event, currentIndex) {
            // ده المفروض يشتغل بناءً على الـ HTML اللي ظهر عندك
            $('.actions a[role="menuitem"]').last().attr('type', 'submit');
        }
    });
    var validationForm = $("#example-validation-form");
    validationForm.val({
        errorPlacement: function errorPlacement(error, element) {
            element.before(error);
        },
        rules: {
            confirm: {
                equalTo: "#password"
            }
        }
    });
    validationForm.children("div").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        onStepChanging: function (event, currentIndex, newIndex) {
            validationForm.val({
                ignore: [":disabled", ":hidden"]
            })
            return validationForm.val();
        },
        onFinishing: function (event, currentIndex) {
            validationForm.val({
                ignore: [':disabled']
            })
            return validationForm.val();
        },
        onFinished: function (event, currentIndex) {
            alert("Submitted!");
        },
        onLastStep: function (event, currentIndex) {
            // استهداف زرار "Finish" في الفورم اللي فيه تحقق
            $('.actions a[role="menuitem"]').last().attr('type', 'submit');
            // أو ممكن تجرب الـ Class اللي ممكن تكون الإضافة بتستخدمه للزرار الأخير
            // $('.actions a.finish').attr('type', 'submit'); // لو الإضافة بتضيف class اسمه 'finish'
        }
    });
    var verticalForm = $("#example-vertical-wizard");
    verticalForm.children("div").steps({
        headerTag: "h3",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        stepsOrientation: "vertical",
        onFinished: function (event, currentIndex) {
            alert("Submitted!");
        },
        onLastStep: function (event, currentIndex) {
            // استهداف زرار "Finish" في الفورم الرأسي
            $('.actions a[role="menuitem"]').last().attr('type', 'submit');
            // أو ممكن تجرب الـ Class اللي ممكن تكون الإضافة بتستخدمه للزرار الأخير
            // $('.actions a.finish').attr('type', 'submit'); // لو الإضافة بتضيف class اسمه 'finish'
        }
    });
})(jQuery);