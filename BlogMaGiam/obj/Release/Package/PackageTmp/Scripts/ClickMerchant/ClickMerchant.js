
var common = new HIA.common();

var clickMerchantJS = {};
(function (context) {
    context.ClickMerchantJs = function () {

        function initialize(params) {
            pageClick();
            $('body').loadingModal('hide');
        }

        function pageClick() {
            $('.pageClick').click(function () {
                var page = $(this)[0].getAttribute("value");
                viewList(page);
            });
        }

        function changeCalendar(element) {
            viewList(pageIndex);
        }

        function viewList(pageIndex) {
            $('body').loadingModal('show');
            var paramQuery = {
                value: $("#value").val(),
                pageIndex: parseInt(pageIndex),
                pageSize: 20,
                type:$("#type").val()
            }
            var options = {
                type: 'POST',
                url: params.urlViewList,
                data: {
                    query: paramQuery
                },
                success: function (data) {
                    $("#table-common").html(data);
                    pageClick();
                    $('body').loadingModal('hide');

                },
                error: function (xhr) {
                    $('body').loadingModal('hide');

                }
            };
            common.ajaxWrapper(options);
        }

        return {
            initialize: initialize,
            viewList: viewList,
            changeCalendar: changeCalendar
        }
    }
})(clickMerchantJS);