
var HIA = {};

(function (context) {
    context.common = function () {

        function ajaxWrapper(options) {
            $.ajax(options);
        }

        function toast(success, message) {
            if (success) { 
                $.toast({
                    heading: 'Success',
                    text: message,
                    showHideTransition: 'slide',
                    icon: 'success',
                    position: 'top-right',
                    hideAfter: 3000
                })
            }
            else {
                $.toast({
                    heading: 'Error',
                    text: message,
                    showHideTransition: 'fade',
                    icon: 'error',
                    position: 'top-right',
                    hideAfter: 3000
                })
            }
           
        }

        function renderMessageError(data) {
            if (data && data.length>0) {
                for (var i = 0; i < data.length; i++) {
                    $("#" + data[i].Key).text(data[i].Value);
                }
            }
        }

        return {
            ajaxWrapper: ajaxWrapper,
            toast: toast,
            renderMessageError: renderMessageError
        }
    }
  
})(HIA);